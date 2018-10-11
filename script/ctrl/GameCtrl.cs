using Cry.Common;
using testUnity.common;
using testUnity.script.model;
using UnityEngine;

namespace testUnity.ctrl {
    public class GameCtrl : MonoBehaviour {
        void Start () {
            Game game = Game.instance;
            game.gameObject = gameObject;
            game.init();
            CameraCtrl.instance.init ();

        }



    }
}