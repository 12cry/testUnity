using System.Collections.Generic;
using testUnity.constant;
using testUnity.model;

namespace testUnity.common {
    public class Tool {
        public static void DialTheCloud (int x, int z, Team team) {
            Land land = ModelRepository.instance.Land;
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
    }
}