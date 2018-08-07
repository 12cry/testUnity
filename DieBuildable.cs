
using UnityEngine;

public class DieBuildable : Buildable
{

    public Material tileMaterial;

    public override void build()
    {
        GameCtrl.currentSelectedTile.setTileType(this);
    }
}