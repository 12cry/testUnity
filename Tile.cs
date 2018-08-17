using testUnity;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour {
    public int x { get; set; }
    public int z { get; set; }
    public bool canMove = false;
    public BuildableType buildableType;

    private void Awake () {

    }
    private void OnMouseDown () {
        GameCtrl.currentSelectedTile = this;
        if (canMove) {
            Player player = GameCtrl.currentSelectedPlayer;
            player.move (this);
            BuildInfoUI.instance.hide ();
        } else {
            BuildInfoUI.instance.show ();
        }

        GameCtrl.clean ();
        GameCtrl.currentSelectedPlayer = null;
    }

    public void enableMove () {
        //todo
        canMove = true;
    }
    public void disableMove () {
        //todo
        canMove = false;
    }
    public void setTileType (int buildableID) {
        DieBuildable buildable = (DieBuildable) GameConfigure.instance.buildableLibrary[buildableID];
        this.setTileType (buildable);
    }
    public void setTileType (DieBuildable buildable) {
        Material m = buildable.tileMaterial;
        this.GetComponent<MeshRenderer> ().sharedMaterial = m;
        this.buildableType = buildable.type;

    }

}