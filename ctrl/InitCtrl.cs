using System.Collections.Generic;
using System.Linq;
using testUnity.common;
using testUnity.model;
using testUnity.service;
using UnityEngine;

namespace testUnity.ctrl {
  public class InitCtrl : MonoBehaviour {
    InitService initService = new InitService ();
    void Start () {
      initService.initLand (this.transform);
      initService.initTeam ();

      // ResourceUI.instance.init ();
      // CameraRig.instance.init (column, row);

    }

    void OnDrawGizmos () {
      Land land = ModelRepository.instance.Land;
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