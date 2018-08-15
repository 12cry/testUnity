using UnityEngine;

namespace testUnity {
    public class GameAI : MonoBehaviour {
        public void run () {
            Player[] players = Object.FindObjectsOfType<Player> ();
            // FindGameObjectsWithTag
            for (int i = 1; i < GameCtrl.totalNumberOfTeam; i++) {
                for (int j = 0; j < players.Length; j++) {
                    Player player = players[j];
                    if (player.team == i) {
                        player.autoRun ();
                    }

                }
            }
        }
    }

}