
using testUnity.constant;
using testUnity.model.builder;
using UnityEngine;

namespace testUnity.model {

    public class Tile {
        public int x;
        public int z;
        public bool canMove = false;
        public BuildType buildType;
        public City city;
        public GameObject gameObject;

        
        public void enableMove () {
            Shader s = Shader.Find ("Custom/mb1");
            gameObject.GetComponent<MeshRenderer> ().material.shader = s;
            canMove = true;
        }
        public void disableMove () {
            canMove = false;
        }

        public void setTileType (BuildType buildType) {
            Material m = null;//
            gameObject.GetComponent<MeshRenderer> ().sharedMaterial = m;
            this.buildType = buildType;
        }
    }
}