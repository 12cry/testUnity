using System.Collections.Generic;
using testUnity.common;

namespace testUnity.model {
    public class City {
        public int x { get; set; }
        public int z { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Team team { get; set; }
        public List<Tile> tileList = new List<Tile> ();

        public void init () {
            Tool.DialTheCloud (x,z,team);
            team.cityList.Add (this);
        }
        

    }
}