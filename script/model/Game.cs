using System.Collections.Generic;
using System.Linq;
using testUnity.common;
using testUnity.constant;
using UnityEngine;

namespace testUnity.script.model {
    public class Game {
        public GameObject gameObject;
        public Land land;
        public BuildPanel buildPanel;
        public ResourcePanel resourcePanel;
        public Dictionary<int, Team> teamDic = new Dictionary<int, Team> ();
        public Dictionary<BuildType, Builder> builderDic;
        public Dictionary<BuildType, int> buildMoneyDic;

        public void init () {
            GameConfigure gameConfigure = GameConfigure.instance;
            builderDic = gameConfigure.buildLibrary.builderList.ToDictionary (t => t.buildType);
            buildMoneyDic = gameConfigure.buildLibrary.builderList.ToDictionary (t => t.buildType, t => t.money);

            land = new Land (gameConfigure.landColumn, gameConfigure.landRow);
            land.init (gameObject.transform);

            initTeam ();

            buildPanel = new BuildPanel ();
            buildPanel.init ();

            resourcePanel = new ResourcePanel ();
            resourcePanel.init ();
        }
        public void initTeam () {

            Team team = new Team ();
            team.id = 0;
            team.isAI = false;
            team.money = 10;
            team.visualTile = new bool[land.column, land.row];
            teamDic[0] = team;

            team = new Team ();
            team.id = 1;
            team.isAI = true;
            team.money = 10;
            team.visualTile = new bool[land.column, land.row];
            teamDic[1] = team;

            StaticVar.currentTeam = teamDic[0];
            StaticVar.currentSelectedTile = getInitBuildCityTile ();
            builderDic[BuildType.City].build ();
            builderDic[BuildType.Warrior].build ();

            StaticVar.currentTeam = teamDic[1];
            StaticVar.currentSelectedTile = getInitBuildCityTile ();
            builderDic[BuildType.City].build ();
            builderDic[BuildType.Warrior].build ();

            StaticVar.currentTeam = teamDic[0];
        }

        Tile getInitBuildCityTile () {
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

        private Game () { }
        private static readonly Game m_instance = new Game ();
        public static Game instance {
            get {
                return m_instance;
            }
        }

    }
}