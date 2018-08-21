using System.Collections.Generic;
using UnityEngine;

namespace testUnity {
    public class GameAI : MonoBehaviour {
        Queue<Player> queue = new Queue<Player> ();
        AIState state = AIState.Finish;

        void Start () {
        }
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
                Static.currentTeamID = 0;
                state = AIState.Finish;
            }

        }

        public void build () {
            Team team = Static.teamDic[1];
            int money = team.money;

            
        }
        public void run () {
            Static.currentGameState = GameState.AIRuning;
            Static.currentTeamID = 1;
            state = AIState.Ready;
        }
    }

}