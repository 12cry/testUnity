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
        public static Tile currentSelectedTile { get; set; }
    }
}