
using testUnity;
using testUnity.ctrl;
using UnityEngine;

public class DynamicBuildable : Buildable
{

    public PlayerCtrl playerCtrl;

    public override void build()
    {
        Tile tile = Static.currentSelectedTile;
        PlayerCtrl playerCtrl = Instantiate(this.playerCtrl);
        Transform t = player.GetComponent<Transform>();
        t.localPosition = new Vector3(tile.x,0,tile.z);
        player.team = Static.currentTeam;
        player.x=tile.x;
        player.z=tile.z;
        player.init();
    }
}