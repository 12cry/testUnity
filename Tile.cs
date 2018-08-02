using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    private void Awake()
    {

    }
    private void OnMouseDown()
    {
        Debug.Log("tile-OnMouseDown-----------");
        Player player = GameCtrl.currentSelectedPlayer;
        if (player != null)
        {
            if (canMove())
            {


                player.move();
            }
            else
            {

            }
        }

        BuildInfoUI.instance.show();
        GameCtrl.currentSelectedTile = this;
    }
    bool canMove()
    {
        return true;
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
