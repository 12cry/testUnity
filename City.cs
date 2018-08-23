using System.Collections.Generic;

namespace testUnity {
    public class City {
        public int x { get; set; }
        public int z { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Team team { get; set; }
        public List<Tile> tileList = new List<Tile>();

        public void init () {
            DialTheCloud ();
            team.cityList.Add (this);
        }
        void DialTheCloud () {
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (x + i < 0 || x + i >= Land.instance.maxX || z + j < 0 || z + j >= Land.instance.maxZ || (i == 0 & j == 0)) {
                        continue;
                    }
                    team.visualTile[x + i, z + j] = true;
                }
            }
        }

    }
}