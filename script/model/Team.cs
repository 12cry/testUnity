using System.Collections.Generic;

namespace testUnity.script.model {
    public class Team {
        public int id { get; set; }
        public bool isAI { get; set; }
        public string name { get; set; }
        public int money { get; set; }
        public bool[, ] visualTile;
        public List<City> cityList = new List<City> ();
        public List<Player> playerList = new List<Player> ();

    }
}