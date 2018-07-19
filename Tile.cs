using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    private void Awake()
    {
        
    }
    private void OnMouseDown()
    {
        GameCtrl.showBuildInfoUI();
        GameCtrl.currentSelectedTile = this;
    }

    public void setTileType(int buildableID)
    {
        Buildable buildable = GameConfigure.instance.buildableLibrary[buildableID];
        //Material m  = buildable.tileMaterial;
        //this.GetComponent<MeshRenderer>().sharedMaterial = m;
    }
}
