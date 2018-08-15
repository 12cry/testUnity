using UnityEngine;

public class Tile : MonoBehaviour {
    public int x { get; set; }
    public int z { get; set; }
    public bool canMove = false;

    private void Awake () {

    }
    private void OnMouseDown () {
        GameCtrl.currentSelectedTile = this;
        Player player = GameCtrl.currentSelectedPlayer;
        if (canMove) {
            player.move (this);
            BuildInfoUI.instance.hide ();
            return ;
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

    }

}