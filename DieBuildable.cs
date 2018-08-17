using testUnity;
using UnityEditor;
using UnityEngine;

public class DieBuildable : Buildable {

    public Material tileMaterial;

    public override void build () {

        if (!canBuild ()) {
            // EditorUtility.DisplayDialog("1","2","3","4");
            Debug.Log ("cannotBuild--------");
            return;
        }
        GameCtrl.currentSelectedTile.setTileType (this);

        reduceMoney ();

        if (type == BuildableType.City) {
            City city = new City ();
            city.id = GameCtrl.cityID++;
            city.civID = GameCtrl.currentCivID;

            Tile[, ] tiles = Land.instance.tiles;
            Tile currentTile = GameCtrl.currentSelectedTile;
            int x = currentTile.x;
            int z = currentTile.z;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {

                    if (x + i < 0 || x + i >= Land.instance.x || z + j < 0 || z + j >= Land.instance.z || (i == 0 & j == 0)) {
                        continue;
                    }
                    Tile tile = tiles[x + i, z + j];
                    if (tile.city == null) {
                        tile.city = city;
                    }
                }
            }
        }
    }

}