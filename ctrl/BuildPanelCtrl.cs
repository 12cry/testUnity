using testUnity.common;
using testUnity.model;
using UnityEngine;

namespace testUnity.ctrl {
    public class BuildPanelCtrl  : MonoBehaviour{
        BuildPanel buildPanel = new BuildPanel();
        void Start () {
            buildPanel.init(transform);
        }
        
        public void show () {
            GetComponent<Canvas> ().enabled = true;
        }
        public void hide () {
            GetComponent<Canvas> ().enabled = false;
        }
    }
}