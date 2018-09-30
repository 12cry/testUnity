using System.Collections.Generic;
using System.Linq;
using testUnity.common;
using testUnity.constant;
using testUnity.model;
using UnityEngine;

namespace testUnity.service {
    public class InitService {

        public void initLand (Transform transform) {
            Land land = new Land (GameConfigure.instance.landColumn, GameConfigure.instance.landRow);
            land.init (transform);
            ModelRepository.instance.Land = land;
        }

        public void initTeam () {
            Land land = ModelRepository.instance.Land;

            Team team = new Team ();
            team.id = 0;
            team.isAI = false;
            team.money = 10;
            team.visualTile = new bool[land.column, land.row];
            StaticVar.teamDic[0] = team;

            team = new Team ();
            team.id = 1;
            team.isAI = true;
            team.money = 10;
            team.visualTile = new bool[land.column, land.row];
            StaticVar.teamDic[1] = team;

            Dictionary<BuildType, Builder> builderDic = StaticVar.builderDic;
            StaticVar.currentTeam = StaticVar.teamDic[0];
            StaticVar.currentSelectedTile = getInitBuildCityTile ();
            builderDic[BuildType.City].build ();
            builderDic[BuildType.Warrior].build ();

            StaticVar.currentTeam = StaticVar.teamDic[1];
            StaticVar.currentSelectedTile = getInitBuildCityTile ();
            builderDic[BuildType.City].build ();
            builderDic[BuildType.Warrior].build ();

            StaticVar.currentTeam = StaticVar.teamDic[0];
        }

        Tile getInitBuildCityTile () {
            Land land = ModelRepository.instance.Land;
            int x = Random.Range (1, land.column - 1);
            int z = Random.Range (1, land.row - 1);
            Tile tile = land.tiles[x, z];

            Tile[, ] tiles = land.tiles;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (tiles[x + i, z + j].city != null) {
                        return getInitBuildCityTile ();
                    }
                }
            }

            return tile;
        }
    }
}