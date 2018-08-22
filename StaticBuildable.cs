using testUnity;
using UnityEditor;
using UnityEngine;

public class StaticBuildable : Buildable {

    public Material tileMaterial;

    public override void build () {

        Static.currentSelectedTile.setTileType (this);
        if (type == BuildableType.City) {
            Tile currentTile = Static.currentSelectedTile;
            int x = currentTile.x;
            int z = currentTile.z;

            City city = new City ();
            city.id = Static.cityID++;
            city.team = Static.currentTeam;
            city.x = x;
            city.z = z;
            city.init();

            Tile[, ] tiles = Static.tiles;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {

                    if (x + i < 0 || x + i >= Land.instance.maxX || z + j < 0 || z + j >= Land.instance.maxZ || (i == 0 & j == 0)) {
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