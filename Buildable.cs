using System.Collections;
using testUnity;
using UnityEngine;

public abstract class Buildable : MonoBehaviour {
    // public int id;
    public BuildableType type;
    public string buildName;
    public int money;

    public abstract void build ();
    public bool canBuild () {
        if (money > ResourceUI.instance.moneyValue) {
            return false;
        }

// if(type==BuildableType.Farm){

// }




        return true;
    }
    public void reduceMoney () {
        ResourceUI.instance.moneyValue -= money;
        ResourceUI.instance.moneyValueText.text = ResourceUI.instance.moneyValue.ToString ();
    }

}