using System.Collections.Generic;
using testUnity.constant;
using testUnity.script.model;

namespace testUnity.common
{
    public class StaticVar
    {
        public static Team currentTeam;
        public static Tile currentSelectedTile;
        public static Player currentSelectedPlayer;
        public static int cityID = 0;
        public static GameState currentGameState = GameState.HumanRuning;

    }
}