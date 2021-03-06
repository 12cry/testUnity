using testUnity.common;
using testUnity.script.model.builder;
using UnityEngine;

namespace testUnity.script.model.builder {
    public class CityBuilder : StaticBuilder {

        public override void build () {
            base.build();
            Tile currentTile = StaticVar.currentSelectedTile;
            int x = currentTile.x;
            int z = currentTile.z;

            City city = new City ();
            city.id = StaticVar.cityID++;
            city.team = StaticVar.currentTeam;
            city.x = x;
            city.z = z;
            city.init ();

            Land land = Game.instance.land;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {

                    if (x + i < 0 || x + i >= land.column || z + j < 0 || z + j >= land.row || (i == 0 & j == 0)) {
                        continue;
                    }
                    Tile tile = land.tiles[x + i, z + j];
                    if (tile.city == null) {
                        tile.city = city;
                        city.tileList.Add (tile);
                    }
                }
            }
        }
    }
}