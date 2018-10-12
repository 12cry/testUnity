using testUnity.common;
using testUnity.script.model;
using UnityEngine;

namespace testUnity.ctrl {
    public class TileCtrl : MonoBehaviour {
        public Tile tile;
        private void OnMouseDown () {
            StaticVar.currentSelectedTile = this.tile;
            Player player = StaticVar.currentSelectedPlayer;
            if (tile.canMove) {
                player.move (tile);
                Game.instance.buildPanel.hide ();
            } else {
                Game.instance.buildPanel.show ();
            }

            player.clean ();
            StaticVar.currentSelectedPlayer = null;
        }

    }
}