
using testUnity;
using UnityEngine;

public class DynamicBuildable : Buildable
{

    public Player player;

    public override void build()
    {
        Tile tile = Static.currentSelectedTile;
        Player player = Instantiate(this.player);
        Transform t = player.GetComponent<Transform>();
        t.localPosition = new Vector3(tile.x,0,tile.z);
        player.teamID = Static.currentTeamID;
        player.x=tile.x;
        player.z=tile.z;
    }
}