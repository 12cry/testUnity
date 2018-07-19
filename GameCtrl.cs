using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl {
    public static Tile currentSelectedTile { get; set; }


    public static void showBuildInfoUI()
    {
        BuildInfoUI.instance.GetComponent<Canvas>().enabled = true;
    }
    public static void hideBuildInfoUI()
    {
        BuildInfoUI.instance.GetComponent<Canvas>().enabled = false;
    }
}
