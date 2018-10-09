

using System.Collections.Generic;
using System.Linq;
using testUnity.common;
using testUnity.constant;
using testUnity.ctrl;
using UnityEngine;

namespace testUnity.model {
    public class BuildPanel {
        public GameObject gameObject;
        List<BuildButtonCtrl> buildButtonCtrlList = new List<BuildButtonCtrl> ();
        Dictionary<BuildType, BuildButtonCtrl> buildButtonCtrlDic;
        List<BuildType> preBuildTypeList;

        public void init () {
            foreach (Builder builder in GameConfigure.instance.buildLibrary.builderList) {
                BuildButtonCtrl buildButtonCtrl = Object.Instantiate (GameConfigure.instance.buildButtonCtrlPrefab, gameObject.transform);
                buildButtonCtrl.transform.localPosition = new Vector3 (1000, 0, 0);
                
                BuildButton buildButton = new BuildButton ();
                buildButton.name = builder.buildType.ToString ();
                buildButton.builder = builder;
                buildButton.text.text = builder.buildName;
                buildButtonCtrl.buildButton = buildButton;

                buildButtonCtrlList.Add (buildButtonCtrl);
            }
            buildButtonCtrlDic = buildButtonCtrlList.ToDictionary (t => t.buildButton.builder.buildType);
        }

        public void show () {
            showBuildButton ();
            gameObject.GetComponent<Canvas> ().enabled = true;
        }
        public void hide () {
            gameObject.GetComponent<Canvas> ().enabled = false;
        }

        public void showBuildButton(){
            if (StaticVar.currentSelectedTile == null) {
                return;
            }
            if (preBuildTypeList != null) {
                foreach (BuildType type in preBuildTypeList) {
                    BuildButtonCtrl buildButtonCtrl = buildButtonCtrlDic[type];
                    buildButtonCtrl.transform.localPosition = new Vector3 (1000, 0, 0);
                }
            }
            List<BuildType> buildTypelist = Tool.getBuildTypeList (StaticVar.currentSelectedTile);
            preBuildTypeList = buildTypelist;
            int i = 1;
            foreach (BuildType type in buildTypelist) {
                BuildButtonCtrl buildButtonCtrl = buildButtonCtrlDic[type];
                buildButtonCtrl.transform.localPosition = new Vector3 (i * 100 - Screen.width / 2, -Screen.height / 2 + 50, 0);
                i++;
            }
        }

        
    }
}