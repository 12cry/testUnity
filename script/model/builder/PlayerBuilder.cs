using testUnity.common;
using testUnity.ctrl;
using UnityEngine;

namespace testUnity.script.model.builder {
    public class PlayerBuilder : Builder {

        public override void build () {
            Tile tile = StaticVar.currentSelectedTile;
            PlayerCtrl playerCtrl = Object.Instantiate (GameConfigure.instance.playerCtrlPrefab);
            Transform t = playerCtrl.GetComponent<Transform> ();
            t.localPosition = new Vector3 (tile.x, 0, tile.z);
            Player player = new Player ();
            player.team = StaticVar.currentTeam;
            player.x = tile.x;
            player.z = tile.z;
            player.gameObject = playerCtrl.gameObject;
            player.init ();
            playerCtrl.player = player;
        }
    }
}