using System.Collections.Generic;
using testUnity.constant;
using testUnity.model;

namespace testUnity.common
{
    public class StaticVar
    {
        public static Dictionary<BuildType, Builder> builderDic;
        public static Dictionary<BuildType, int> buildMoneyDic;
        public static Dictionary<int, Team> teamDic = new Dictionary<int, Team> ();
        public static Team currentTeam;
        public static Tile currentSelectedTile;
        public static Player currentSelectedPlayer;
        public static int cityID = 0;
        public static List<Tile> moveableTileList = new List<Tile> ();
        public static List<Player> attackablePlayerList = new List<Player> ();
        public static GameState currentGameState = GameState.HumanRuning;

    }
}