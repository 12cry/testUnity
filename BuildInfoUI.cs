using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cry.Common;
using testUnity;
using UnityEngine;
using UnityEngine.UI;

public class BuildInfoUI : Singleton<BuildInfoUI> {

    List<BuildableButtonUI> buildableButtonUIList = new List<BuildableButtonUI> ();
    Dictionary<BuildableType, BuildableButtonUI> buildableButtonUIDictionary;
    List<BuildableType> oldBuildableTypelist;
    protected override void Awake () {
        base.Awake ();
        // hide();
    }
    void Start () {
        foreach (Buildable buildable in GameConfigure.instance.buildableLibrary) {
            BuildableButtonUI newBTUI = Instantiate (GameConfigure.instance.buildableButtonUI, transform);
            newBTUI.buildable = buildable;
            newBTUI.text.text = buildable.buildName;
            newBTUI.transform.localPosition = new Vector3 (1000, 0, 0);
            buildableButtonUIList.Add (newBTUI);
        }
        buildableButtonUIDictionary = buildableButtonUIList.ToDictionary (t => t.buildable.type);
    }

    public List<BuildableType> getBuildableTypeList (Tile tile) {
        BuildableType type = tile.buildableType;
        List<BuildableType> typeList = new List<BuildableType> ();
        if (type == BuildableType.Flat) {
            typeList.Add (BuildableType.City);
            typeList.Add (BuildableType.Mountain);
        } else if (type == BuildableType.Mountain) {
            typeList.Add (BuildableType.City);
        } else if (type == BuildableType.City) {

        }
        return typeList;
    }
    public void show () {
        if (GameCtrl.currentSelectedTile == null) {
            return;
        }
        if (oldBuildableTypelist != null) {
            foreach (BuildableType type in oldBuildableTypelist) {
                BuildableButtonUI bbui = buildableButtonUIDictionary[type];
                bbui.transform.localPosition = new Vector3 (1000, 0, 0);
            }
        }
        List<BuildableType> buildableTypelist = this.getBuildableTypeList (GameCtrl.currentSelectedTile);
        oldBuildableTypelist = buildableTypelist;
        int i = 1;
        foreach (BuildableType type in buildableTypelist) {
            BuildableButtonUI bbui = buildableButtonUIDictionary[type];
            bbui.transform.localPosition = new Vector3 (i * 100 - 200, 0, 0);
            i++;
        }
        GetComponent<Canvas> ().enabled = true;
    }
    public void hide () {
        GetComponent<Canvas> ().enabled = false;
    }
}