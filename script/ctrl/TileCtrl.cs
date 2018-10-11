using testUnity.common;
using testUnity.script.model;
using UnityEngine;

namespace testUnity.ctrl
{
    public class TileCtrl: MonoBehaviour
    {
        public Tile tile;
        private void OnMouseDown () {
            StaticVar.currentSelectedTile = this.tile;
            if (tile.canMove) {
                Player player = StaticVar.currentSelectedPlayer;
                player.move (tile);
                Game.instance.buildPanel.hide ();
            } else {
                Game.instance.buildPanel.show ();
            }

            Tool.clean ();
            StaticVar.currentSelectedPlayer = null;
        }


    }
}