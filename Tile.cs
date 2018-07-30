using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler, IDragHandler
{

    private void Awake()
    {

    }
    public void test()
    {
        Debug.Log("test--");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag-----------");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick-----------");
        PhysicsRaycaster t;
    }
    private void OnMouseDown()
    {
        Debug.Log("tile-OnMouseDown-----------");
        // SendMouseEvents.Equals();
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
        this.setTileType(buildable);
    }
    public void setTileType(Buildable buildable)
    {
        Material m = buildable.tileMaterial;
        this.GetComponent<MeshRenderer>().sharedMaterial = m;
    }

}
