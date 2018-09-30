using System.Collections;
using System.Collections.Generic;
using testUnity;
using testUnity.ctrl;
using testUnity.model;
using UnityEngine;

namespace testUnity {
    public class Static {
        public static List<Tile> moveableTileList = new List<Tile> ();
        public static List<Player> attackablePlayerList = new List<Player> ();
        public static Player currentSelectedPlayer { get; set; }
        public static GameState currentGameState = GameState.HumanRuning;
        public static int cityID = 0;

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
                PlayerCtrl playerCtrl = hit.collider.GetComponent<PlayerCtrl> ();
                if (playerCtrl != null) {
                    player = playerCtrl.player;
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