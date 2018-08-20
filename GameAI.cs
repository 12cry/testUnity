using System.Collections.Generic;
using UnityEngine;

namespace testUnity {
    public class GameAI : MonoBehaviour {
        Queue<Player> queue = new Queue<Player> ();
        void Update () {

            if (Static.currentGameState == GameState.AIRuning) {
                if (Static.currentAIState == AIState.Finish) {
                    if (queue.Count > 0) {
                        Player player = queue.Dequeue ();
                        if (player != null) {
                            Debug.Log ("AIRuning-----");
                            Static.currentAIState = AIState.Playing;
                            player.aIState = AIState.Ready;
                        }

                    } else {
                        Static.currentGameState = GameState.HumanRuning;
                        Debug.Log ("HumanRuning-----");
                        ResourceUI.instance.moneyValueText.text = "2";
                        Static.currentTeamID = 0;
                    }

                }
            }

        }
        public void run () {
            GameObject[] gos = GameObject.FindGameObjectsWithTag ("team1");
            foreach (GameObject go in gos) {
                Player player = go.GetComponent<Player> ();
                queue.Enqueue (player);
            }
            Static.currentGameState = GameState.AIRuning;
            Static.currentTeamID = 1;
        }
    }

}