using testUnity;
using testUnity.constant;
using UnityEngine;
using UnityEngine.EventSystems;
namespace testUnity.model {

    public class Tile : MonoBehaviour {
        public int x { get; set; }
        public int z { get; set; }
        public bool canMove = false;
        public BuildType buildType;
        public City city;

        private void Awake () {

        }
        private void OnMouseDown () {
            Static.currentSelectedTile = this;
            if (canMove) {
                Player player = Static.currentSelectedPlayer;
                player.move (this);
                BuildInfoUI.instance.hide ();
            } else {
                BuildInfoUI.instance.show ();
            }

            Static.clean ();
            Static.currentSelectedPlayer = null;
        }

        public void enableMove () {
            //todo
            Shader s = Shader.Find ("Custom/mb1");
            print (s);
            GetComponent<MeshRenderer> ().material.shader = s;
            canMove = true;
        }
        public void disableMove () {
            //todo
            canMove = false;
        }

        public void setTileType (StaticBuildable buildable) {
            Material m = buildable.tileMaterial;
            this.GetComponent<MeshRenderer> ().sharedMaterial = m;
            this.buildableType = buildable.type;

        }

    }
}