using testUnity.constant;
using testUnity.ctrl;
using UnityEngine;

namespace testUnity.model {

    public class Land {
        public GameObject gameObject;
        public int column;
        public int row;
        public Tile[, ] tiles;

        public Land (int column, int row) {
            this.column = column;
            this.row = row;
        }

        public void init () {
            tiles = new Tile[column, row];
            for (int i = 0; i < column; i++) {
                for (int j = 0; j < row; j++) {
                    TileCtrl tileCtrl = Object.Instantiate (GameConfigure.instance.tileCtrlPrefab);
                    tileCtrl.transform.parent = gameObject.transform;
                    tileCtrl.transform.localPosition = new Vector3 (i, 0, j);

                    Tile tile = new Tile ();
                    tile.x = i;
                    tile.z = j;
                    tile.buildType = BuildType.Flat;

                    tileCtrl.tile = tile;
                    tiles[i, j] = tile;
                }
            }
        }

    }
}