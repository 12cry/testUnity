using testUnity.common;
using testUnity.model;
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
                BuildPanelCtrl.instance.hide ();
            } else {
                BuildPanelCtrl.instance.show ();
            }

            Tool.clean ();
            StaticVar.currentSelectedPlayer = null;
        }


    }
}