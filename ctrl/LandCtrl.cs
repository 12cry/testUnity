using Cry.Common;
using testUnity.common;
using testUnity.model;
using UnityEngine;

namespace testUnity.ctrl {
    public class LandCtrl : MonoBehaviour {
        Land land;
        void Awake()
        {
            land  = new Land(GameConfigure.instance.landColumn,GameConfigure.instance.landRow);
            land.gameObject = gameObject;
            land.init();
            ModelRepository.instance.land = land;
        }

        
        void OnDrawGizmos () {
            Color prevCol = Gizmos.color;
            Gizmos.color = Color.cyan;

            Matrix4x4 originalMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;

            for (int j = 0; j < land.row; j++) {
                for (int i = 0; i < land.column; i++) {
                    var position = new Vector3 (i, 0, j);
                    Gizmos.DrawWireCube (position, new Vector3 (1, 0, 1));
                }
            }
            Gizmos.matrix = originalMatrix;
            Gizmos.color = prevCol;

        }
    }
}