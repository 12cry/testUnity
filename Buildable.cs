using UnityEngine;
using System.Collections;
using testUnity;

public abstract class Buildable : MonoBehaviour
{
    // public int id;
    public BuildableType type;
    public string buildName;

    public abstract void build();

}