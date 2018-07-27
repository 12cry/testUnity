using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    private void Awake()
    {
        
    }
    private void OnMouseDown()
    {
        Player player = GameCtrl.currentSelectedPlayer;
        if ( player!= null)
        {
            if (canMove())
            {
                

                player.move();
            }
            else
            {

            }
        }
        //GameCtrl.showBuildInfoUI();
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
        Material m = buildable.tileMaterial;
        this.GetComponent<MeshRenderer>().sharedMaterial = m;
    }
}
