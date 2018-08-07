using UnityEngine;
using System.Collections;

public abstract class Buildable : MonoBehaviour
{
    public int id;
    public string buildName;

    public abstract void build();

}