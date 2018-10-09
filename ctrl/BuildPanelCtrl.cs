using Cry.Common;
using testUnity.common;
using testUnity.model;
using UnityEngine;

namespace testUnity.ctrl {
    public class BuildPanelCtrl : MonoBehaviour {
        BuildPanel buildPanel = new BuildPanel ();

        void Awake()
        {
            buildPanel.gameObject = gameObject;
            ModelRepository.instance.buildPanel = buildPanel;
        }
        void Start () {
            buildPanel.init ();
        }

    }
}