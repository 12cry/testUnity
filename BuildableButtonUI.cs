using System;
using testUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildableButtonUI : MonoBehaviour {
    public Button button;
    public Text text;
    public Buildable buildable;

    public void onClick () {
        if (buildable.money > Static.currentTeam.money) {
            Debug.Log ("cannotBuild--------");
            return;
        }

        buildable.build ();

        reduceMoney();
    }
   
    public void reduceMoney () {
        Team team = Static.currentTeam;
        team.money -= buildable.money;
        ResourceUI.instance.moneyValueText.text = team.money.ToString ();
    }


}