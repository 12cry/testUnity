using UnityEngine;
using System.Collections;

public class Buildable : MonoBehaviour
{
    public int id;
    public string buildName;
    public Material tileMaterial;


    public void build()
    {
        Debug.Log("build------");
    }
}
