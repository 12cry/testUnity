using System.Collections.Generic;
using UnityEngine;

namespace testUnity {
    public class GameAI : MonoBehaviour {
        Queue<Player> queue = new Queue<Player> ();
        AIState state = AIState.Finish;

        void Start () { }
        void Update () {

            if (state == AIState.Finish) {
                return;
            }

            if (state == AIState.Ready) {
                state = AIState.Building;
                build ();
                state = AIState.Builded;
            }

            if (state == AIState.Builded) {
                GameObject[] gos = GameObject.FindGameObjectsWithTag ("team1");
                foreach (GameObject go in gos) {
                    Player player = go.GetComponent<Player> ();
                    queue.Enqueue (player);
                }
                state = AIState.Playing;
            }

            if (state == AIState.Playing) {
                if (Static.currentPlayerState == PlayerState.Finish) {
                    if (queue.Count > 0) {
                        Player player = queue.Dequeue ();
                        Static.currentPlayerState = PlayerState.Playing;
                        player.state = PlayerState.Ready;
                    } else {
                        state = AIState.Played;
                    }
                }
            }

            if (state == AIState.Played) {
                Static.currentGameState = GameState.HumanRuning;
                ResourceUI.instance.moneyValueText.text = "2";
                Static.currentTeam = Static.teamDic[0];
                state = AIState.Finish;
            }

        }

        public void build () {
            Team team = Static.currentTeam;
            int money = team.money;
            int cityMoney = Static.buildMoneyDic[BuildableType.City];
            int warriorMoney = Static.buildMoneyDic[BuildableType.Warrior];
            // enemy/resource
            foreach (City city in team.cityList) {
                int x = city.x;
                int z = city.z;
                int r = 2;
                int meStrength = 0;
                int enemyStrength = 0;

                if (money < warriorMoney) {
                    break;
                }
                for (int i = -r; i <= r; i++) {
                    for (int j = -r; j <= r; j++) {
                        if (x + i < 0 || x + i >= Land.instance.maxX || z + j < 0 || z + j >= Land.instance.maxZ || (i == 0 & j == 0)) {
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

                }

                if (city.getPlayerInCity () == null) {
                    Static.currentSelectedTile = Static.tiles[city.x, city.z];
                    Static.buildableDic[BuildableType.Warrior].build ();
                }
            }
            if (money > cityMoney) {
                Tile tile = getTheBestCityTile ();
                if (tile != null) {
                    Static.currentSelectedTile = tile;
                    Static.buildableDic[BuildableType.City].build ();
                }
            }

        }

        Tile getTheBestCityTile () {

            return null;
        }
        public void run () {
            Static.currentGameState = GameState.AIRuning;
            Static.currentTeam = Static.teamDic[1];
            state = AIState.Ready;
        }
    }

}