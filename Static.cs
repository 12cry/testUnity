using System.Collections;
using System.Collections.Generic;
using testUnity;
using UnityEngine;

namespace testUnity {
    public class Static {
        public static List<Tile> moveableTileList = new List<Tile> ();
        public static List<Player> attackablePlayerList = new List<Player> ();
        public static Dictionary<int, Team> teamDic = new Dictionary<int, Team> ();
        public static Dictionary<BuildableType, int> buildMoneyDic;
        public static Dictionary<BuildableType, Buildable> buildableDic;
        public static Tile currentSelectedTile { get; set; }
        public static Player currentSelectedPlayer { get; set; }
        public static GameState currentGameState = GameState.HumanRuning;
        public static Team currentTeam;
        public static int cityID = 0;
        public static Tile[, ] tiles;

        public static void build (BuildableType buildableType, int x, int z) {
            build(buildableType,Static.tiles[x, z]);
        }
        public static void build (BuildableType buildableType, Tile tile) {
            Static.currentSelectedTile = tile;
            Static.buildableDic[buildableType].build ();
        }
        public static Player findPlayer (int i, int j) {
            Player player = null;
            RaycastHit hit;
            Vector3 pos = Camera.main.WorldToScreenPoint (new Vector3 (i, 0, j));
            Ray ray = Camera.main.ScreenPointToRay (pos);

            if (Physics.Raycast (ray, out hit)) {
                player = hit.collider.GetComponent<Player> ();
                if (player != null) {
                    Debug.DrawLine (ray.origin, hit.point, Color.red, 200);

                }
            }
            return player;
        }
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