using System.Collections.Generic;
using testUnity.common;
using testUnity.constant;
using testUnity.model;
using UnityEngine;

namespace testUnity.ctrl {
    public class AICtrl : MonoBehaviour {
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
                StaticVar.currentGameState = GameState.HumanRuning;
                StaticVar.currentTeam = StaticVar.teamDic[0];
                reward ();
                state = AIState.Finish;
            }

        }

        public void reward () {
            Team team = StaticVar.currentTeam;
            int money = team.money;
            foreach (City city in team.cityList) {
                money += 1;
                foreach (Tile tile in city.tileList) {
                    if (tile.buildType == BuildType.Farm) {
                        money += 2;
                    }
                }
            }
            if (!team.isAI) {
                ResourceCtrl.instance.moneyValueText.text = money.ToString ();
            }
        }

        public void build () {
            Team team = StaticVar.currentTeam;
            Land land = ModelRepository.instance.land;
            int money = team.money;
            int cityMoney = StaticVar.buildMoneyDic[BuildType.City];
            int warriorMoney = StaticVar.buildMoneyDic[BuildType.Warrior];
            int farmMoney = StaticVar.buildMoneyDic[BuildType.Farm];
            if (!enoughMoneyToBuild ()) {
                return;
            }
            foreach (City city in team.cityList) {
                int x = city.x;
                int z = city.z;
                int r = 2;
                int meStrength = 0;
                int enemyStrength = 0;

                if (money < warriorMoney || Tool.findPlayer (x, z) == null) {
                    break;
                }
                for (int i = -r; i <= r; i++) {
                    for (int j = -r; j <= r; j++) {
                        if (x + i < 0 || x + i >= land.column || z + j < 0 || z + j >= land.row) {
                            continue;
                        }
                        Player player = Tool.findPlayer (x + i, z + j);
                        if (player != null) {
                            if (player.team == StaticVar.currentTeam) {
                                meStrength += 1;
                            } else {
                                enemyStrength += 1;
                            }
                        }
                    }
                }
                if (meStrength < enemyStrength) {
                    Tool.build (BuildType.Warrior, x, z);
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
                    if (tile.buildType == BuildType.Flat) {
                        Tool.build (BuildType.Farm, tile);
                    }
                }
            }
            if (money > cityMoney) {
                Tile tile = getTheBestCityTile ();
                if (tile != null) {
                    Tool.build (BuildType.City, tile);
                }
            }

        }

        bool enoughMoneyToBuild () {
            if (StaticVar.currentTeam.money < 1) {
                return false;
            }
            return true;
        }
        Tile getTheBestCityTile () {

            return null;
        }
        public void run () {
            StaticVar.currentGameState = GameState.AIRuning;
            StaticVar.currentTeam = StaticVar.teamDic[1];
            reward ();
            List<Player> playerList = StaticVar.currentTeam.playerList;
            foreach (Player player in playerList) {
                queue.Enqueue (player);
            }
            state = AIState.Ready;
        }
    }
}