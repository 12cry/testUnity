using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cry.Common;
using testUnity;
using UnityEngine;
using UnityEngine.UI;

public class BuildInfoUI : Singleton<BuildInfoUI> {

    public List<BuildableButtonUI> buildableButtonUIList = new List<BuildableButtonUI> ();
    Dictionary<BuildableType, BuildableButtonUI> buildableButtonUIDictionary;
    List<BuildableType> oldBuildableTypelist;
    protected override void Awake () {
        base.Awake ();
        // hide();
    }
    void Start () {
        foreach (Buildable buildable in GameConfigure.instance.buildableLibrary) {
            BuildableButtonUI newBBUT = Instantiate (GameConfigure.instance.buildableButtonUI, transform);
            newBBUT.name = buildable.type.ToString ();
            newBBUT.buildable = buildable;
            newBBUT.text.text = buildable.buildName;
            newBBUT.transform.localPosition = new Vector3 (1000, 0, 0);
            buildableButtonUIList.Add (newBBUT);
        }
        buildableButtonUIDictionary = buildableButtonUIList.ToDictionary (t => t.buildable.type);
    }

    public List<BuildableType> getBuildableTypeList (Tile tile) {
        BuildableType type = tile.buildableType;
        List<BuildableType> typeList = new List<BuildableType> ();
        if (type == BuildableType.Flat) {
            if (tile.city == null) {
                typeList.Add (BuildableType.City);
            }
            if (tile.city != null && tile.city.teamID == Static.currentTeamID) {
                typeList.Add (BuildableType.Farm);
            }
        } else if (type == BuildableType.Mountain) {
        } else if (type == BuildableType.City) {
            typeList.Add (BuildableType.Warrior);
        }
        return typeList;
    }
    public void show () {
        if (Static.currentSelectedTile == null) {
            return;
        }
        if (oldBuildableTypelist != null) {
            foreach (BuildableType type in oldBuildableTypelist) {
                BuildableButtonUI bbui = buildableButtonUIDictionary[type];
                bbui.transform.localPosition = new Vector3 (1000, 0, 0);
            }
        }
        List<BuildableType> buildableTypelist = this.getBuildableTypeList (Static.currentSelectedTile);
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