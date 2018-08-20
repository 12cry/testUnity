using System.Collections;
using System.Collections.Generic;
using testUnity;
using UnityEngine;

namespace testUnity {
    public class Static {
        public static Tile currentSelectedTile { get; set; }
        public static Player currentSelectedPlayer { get; set; }
        public static List<Tile> moveableTileList = new List<Tile> ();
        public static List<Player> attackablePlayerList = new List<Player> ();
        public static int totalNumberOfTeam = 3;
        public static int currentTeamID = 0;
        public static GameState currentGameState = GameState.HumanRuning;
        public static AIState currentAIState = AIState.Finish;
        public static int cityID = 0;

        public static void clean () {
            cleanAttachablePlayerList ();
            cleanMoveableTileList ();
        }
        public static void cleanMoveableTileList () {
            foreach (Tile tile in moveableTileList) {
                tile.disableMove ();
            }
            moveableTileList.Clear ();
        }

        public static void cleanAttachablePlayerList () {
            foreach (Player player in attackablePlayerList) {
                player.disableAttack ();
            }
            attackablePlayerList.Clear ();
        }

        public static Material getMbMaterial () {

            Shader shader = Shader.Find ("Custom/mb1");
            Material material = new Material (shader) {
                name = "cryTest",
                hideFlags = HideFlags.DontSave,
            };
            return material;

        }
    }
}