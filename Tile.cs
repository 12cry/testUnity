using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public int x { get; set; }
    public int z { get; set; }
    bool canMove { get; set; }

    private void Awake()
    {

    }
    private void OnMouseDown()
    {
        Debug.Log("tile-OnMouseDown-----------");
        GameCtrl.currentSelectedTile = this;
        Player player = GameCtrl.currentSelectedPlayer;
        if (canMove)
        {
            player.move();
            BuildInfoUI.instance.hide();
        }
        else
        {
            BuildInfoUI.instance.show();
        }

        GameCtrl.cleanTiles();
        GameCtrl.currentSelectedPlayer = null;
    }

    public void enableMove()
    {
        //...
        canMove = true;
    }
    public void disableMove()
    {
        canMove = false;
    }
    public void setTileType(int buildableID)
    {
        Buildable buildable = GameConfigure.instance.buildableLibrary[buildableID];
        this.setTileType(buildable);
    }
    public void setTileType(Buildable buildable)
    {
        Material m = buildable.tileMaterial;
        this.GetComponent<MeshRenderer>().sharedMaterial = m;
    }

}
