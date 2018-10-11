using System.Collections;
using System.Collections.Generic;
using System.Linq;
using testUnity;
using testUnity.common;
using testUnity.ctrl;
using testUnity.script.model;
using UnityEngine;

[CreateAssetMenu (fileName = "BuildLibrary.asset", menuName = "cry/buildList", order = 1)]
public class BuildLibrary : ScriptableObject {

    public List<Builder> builderList;

    public void OnAfterDeserialize () {
        if (builderList == null) {
            return;
        }

        // StaticVar.builderDic = builderList.ToDictionary (t => t.buildType);
        // StaticVar.buildMoneyDic = builderList.ToDictionary (t => t.buildType, t => t.money);
    }
}