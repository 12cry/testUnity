using testUnity.common;
using testUnity.script.model;
using UnityEngine;
using UnityEngine.UI;

namespace testUnity.ctrl {
    public class BuildButtonCtrl : MonoBehaviour {
        public BuildButton buildButton;
        public Text text;
        void OnMouseDown () {
            Debug.Log ("OnMouseDown--------");
        }
        public void onClick () {
            Debug.Log ("build--------");
            if (buildButton.builder.money > StaticVar.currentTeam.money) {
                Debug.Log ("cannotBuild--------");
                return;
            }

            buildButton.builder.build ();
            buildButton.reduceMoney ();
        }

    }
}