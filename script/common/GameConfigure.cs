using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cry.Common;
using testUnity.ctrl;
using testUnity.script.model;
using UnityEngine;

namespace testUnity.common {
    public class GameConfigure : Singleton<GameConfigure> {
        public int landColumn;
        public int landRow;

        public BuildLibrary buildLibrary;

        public BuildButtonCtrl buildButtonCtrlPrefab;
        public PlayerCtrl playerCtrlPrefab;
        public TileCtrl tileCtrlPrefab;

        protected override void Awake () {
            base.Awake ();
            init ();

        }

        void init () {

        }

        void OnDrawGizmos () {
            Color prevCol = Gizmos.color;
            Gizmos.color = Color.cyan;

            Matrix4x4 originalMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;

            for (int j = 0; j < landRow; j++) {
                for (int i = 0; i < landColumn; i++) {
                    var position = new Vector3 (i, 0, j);
                    Gizmos.DrawWireCube (position, new Vector3 (1, 0, 1));
                }
            }
            Gizmos.matrix = originalMatrix;
            Gizmos.color = prevCol;

        }
    }
    
}