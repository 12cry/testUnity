using System.Collections.Generic;
using UnityEngine;

namespace testUnity {
    public class GameAI : MonoBehaviour {
        Queue<Player> queue = new Queue<Player> ();
        void Update () {

            if (GameCtrl.currentGameState == GameState.AIRuning) {
                if (GameCtrl.currentAIState == AIState.Finish) {
                    if (queue.Count > 0) {
                        Player player = queue.Dequeue ();
                        Debug.Log (player.name);
                        if (player != null) {
                            GameCtrl.currentAIState = AIState.Playing;
                            player.aIState = AIState.Ready;
                        }

                    } else {
                        GameCtrl.currentGameState = GameState.Normal;
                    }

                }
            }

        }
        public void run () {
            GameObject[] gos = GameObject.FindGameObjectsWithTag ("team1");
            foreach (GameObject go in gos) {
                Player player = go.GetComponent<Player> ();
                Debug.Log (player.name + "------" + player.aIState);
                queue.Enqueue (player);
            }
            GameCtrl.currentGameState = GameState.AIRuning;
        }
    }

}