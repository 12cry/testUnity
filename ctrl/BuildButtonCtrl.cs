using testUnity.common;
using testUnity.model;
using UnityEngine;

namespace testUnity.ctrl {
    public class BuildButtonCtrl : MonoBehaviour {
        public BuildButton buildButton;
        public void onClick () {
            if (buildButton.builder.money > StaticVar.currentTeam.money) {
                Debug.Log ("cannotBuild--------");
                return;
            }

            buildButton.builder.build ();
            buildButton.reduceMoney ();
        }

    }
}