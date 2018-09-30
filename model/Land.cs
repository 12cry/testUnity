using UnityEngine;

namespace testUnity.model {

    public class Land {
        public int column;
        public int row;
        public Tile[, ] tiles;
        
        public Land (int column, int row) {
            this.column = column;
            this.row = row;
        }

        public void init (Transform transform) {
            tiles = new Tile[column, row];
            for (int i = 0; i < column; i++) {
                for (int j = 0; j < row; j++) {
                    Vector3 v = new Vector3 (i, 0, j);
                    Tile newTile = Object.Instantiate (GameConfigure.instance.tile);
                    newTile.x = i;
                    newTile.z = j;
                    newTile.transform.parent = transform;
                    newTile.transform.localPosition = v;
                    newTile.buildableType = BuildableType.Flat;
                    tiles[i, j] = newTile;
                }
            }
        }

    }
}