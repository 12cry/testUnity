using System.Collections;
using testUnity;
using UnityEngine;

public abstract class Buildable : MonoBehaviour {
    public BuildableType type;
    public string buildName;
    public int money;

    public abstract void build ();
}