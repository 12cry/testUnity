using System.Collections.Generic;
using testUnity.constant;
using testUnity.ctrl;
using testUnity.script.model;
using UnityEngine;

namespace testUnity.common {
    public class Tool {
        public static void DialTheCloud (int x, int z, Team team) {
            Land land = Game.instance.land;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (x + i < 0 || x + i >= land.column || z + j < 0 || z + j >= land.row || (i == 0 & j == 0)) {
                        continue;
                    }
                    team.visualTile[x + i, z + j] = true;
                }
            }
        }
        public static List<BuildType> getBuildTypeList (Tile tile) {
            BuildType type = tile.buildType;
            List<BuildType> typeList = new List<BuildType> ();
            if (type == BuildType.Flat) {
                if (tile.city == null) {
                    typeList.Add (BuildType.City);
                }
                if (tile.city != null && tile.city.team == StaticVar.currentTeam) {
                    typeList.Add (BuildType.Farm);
                }
            } else if (type == BuildType.Mountain) { } else if (type == BuildType.City) {
                typeList.Add (BuildType.Warrior);
            }
            return typeList;
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
        // public static void clean () {
        //     cleanAttachablePlayerList ();
        //     cleanMoveableTileList ();
        // }
        // public static void cleanMoveableTileList () {
        //     foreach (Tile tile in StaticVar.moveableTileList) {
        //         tile.disableMove ();
        //     }
        //     StaticVar.moveableTileList.Clear ();
        // }

        // public static void cleanAttachablePlayerList () {
        //     foreach (Player player in StaticVar.attackablePlayerList) {
        //         player.disableAttack ();
        //     }
        //     StaticVar.attackablePlayerList.Clear ();
        // }

        public static Material getMbMaterial () {

            Shader shader = Shader.Find ("Custom/mb1");
            Material material = new Material (shader) {
                name = "cryTest",
                hideFlags = HideFlags.DontSave,
            };
            return material;

        }
        


        public static void build (BuildType buildType, int x, int z) {
            build(buildType,Game.instance.land.tiles[x, z]);
        }
        public static void build (BuildType buildType, Tile tile) {
            StaticVar.currentSelectedTile = tile;
            Game.instance.builderDic[buildType].build ();
        }
    }
}