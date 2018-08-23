using System.Collections;
using System.Collections.Generic;
using System.Linq;
using testUnity;
using UnityEngine;

[CreateAssetMenu (fileName = "BuildableLibrary.asset", menuName = "cry/buildableList", order = 1)]
public class BuildableLibrary : ScriptableObject {

    public List<Buildable> buildableList;

    public void OnAfterDeserialize () {
        Debug.Log("OnAfterDeserialize------");
        if (buildableList == null) {
            return;
        }
    }
}