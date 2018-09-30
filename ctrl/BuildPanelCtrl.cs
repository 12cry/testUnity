using Cry.Common;
using testUnity.common;
using testUnity.model;
using UnityEngine;

namespace testUnity.ctrl {
    public class BuildPanelCtrl : Singleton<BuildPanelCtrl> {
        BuildPanel buildPanel = new BuildPanel ();
        void Start () {
            buildPanel.init (transform);
        }

        public void show () {
            buildPanel.showBuildButton ();
            GetComponent<Canvas> ().enabled = true;
        }
        public void hide () {
            GetComponent<Canvas> ().enabled = false;
        }
    }
}