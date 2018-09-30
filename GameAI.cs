using System.Collections.Generic;
using UnityEngine;

namespace testUnity {
    public class GameAI : MonoBehaviour {
        Queue<Player> queue = new Queue<Player> ();
        AIState state = AIState.Finish;
        Player currentPlayer;
        bool strong = true;

        void Start () { }
        void Update () {

            if (state == AIState.Finish) {
                return;
            }

            if (state == AIState.Ready) {
                build ();
                state = AIState.Builded;
            }

            if (state == AIState.Builded) {
                state = AIState.Playing;
            }

            if (state == AIState.Playing) {
                if (currentPlayer == null || currentPlayer.state == PlayerState.Finish) {
                    if (queue.Count > 0) {
                        currentPlayer = queue.Dequeue ();
                        currentPlayer.state = PlayerState.Ready;
                    } else if (!strong && enoughMoneyToBuild ()) {
                        state = AIState.Ready;
                    } else {
                        state = AIState.Played;
                    }
                }
            }

            if (state == AIState.Played) {
                Static.currentGameState = GameState.HumanRuning;
                Static.currentTeam = Static.teamDic[0];
                reward ();
                state = AIState.Finish;
            }

        }

        public void reward () {
            Team team = Static.currentTeam;
            int money = team.money;
            foreach (City city in team.cityList) {
                money += 1;
                foreach (Tile tile in city.tileList) {
                    if (tile.buildableType == BuildableType.Farm) {
                        money += 2;
                    }
                }
            }
            if (!team.isAI) {
                ResourceCtrl.instance.moneyValueText.text = money.ToString ();
            }
        }

        public void build () {
            Team team = Static.currentTeam;
            int money = team.money;
            int cityMoney = Static.buildMoneyDic[BuildableType.City];
            int warriorMoney = Static.buildMoneyDic[BuildableType.Warrior];
            int farmMoney = Static.buildMoneyDic[BuildableType.Farm];
            if (!enoughMoneyToBuild ()) {
                return;
            }
            foreach (City city in team.cityList) {
                int x = city.x;
                int z = city.z;
                int r = 2;
                int meStrength = 0;
                int enemyStrength = 0;

                if (money < warriorMoney || Static.findPlayer (x, z) == null) {
                    break;
                }
                for (int i = -r; i <= r; i++) {
                    for (int j = -r; j <= r; j++) {
                        if (x + i < 0 || x + i >= Land.instance.maxX || z + j < 0 || z + j >= Land.instance.maxZ) {
                            continue;
                        }
                        Player player = Static.findPlayer (x + i, z + j);
                        if (player != null) {
                            if (player.team == Static.currentTeam) {
                                meStrength += 1;
                            } else {
                                enemyStrength += 1;
                            }
                        }
                    }
                }
                if (meStrength < enemyStrength) {
                    Static.build (BuildableType.Warrior, x, z);
                    strong = false;
                }
            }

            if (!strong) {
                return;
            }

            foreach (City city in team.cityList) {
                if (money < farmMoney) {
                    break;
                }
                foreach (Tile tile in city.tileList) {
                    if (money < farmMoney) {
                        break;
                    }
                    if (tile.buildableType == BuildableType.Flat) {
                        Static.build (BuildableType.Farm, tile);
                    }
                }
            }
            if (money > cityMoney) {
                Tile tile = getTheBestCityTile ();
                if (tile != null) {
                    Static.build (BuildableType.City, tile);
                }
            }

        }

        bool enoughMoneyToBuild () {
            if (Static.currentTeam.money < 1) {
                return false;
            }
            return true;
        }
        Tile getTheBestCityTile () {

            return null;
        }
        public void run () {
            Static.currentGameState = GameState.AIRuning;
            Static.currentTeam = Static.teamDic[1];
            reward ();
            List<Player> playerList = Static.currentTeam.playerList;
            foreach (Player player in playerList) {
                queue.Enqueue (player);
            }
            state = AIState.Ready;
        }
    }

}