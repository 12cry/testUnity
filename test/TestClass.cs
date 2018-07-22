using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CreateAssetMenu]
public class TestClass : ScriptableObject
{
    [Range(0, 10)]
    public int intData;
    public string stringData;
    public List<DataClass> dataList;
    public Buildable a;
}

[System.Serializable]
public class DataClass
{
    [Range(0, 100)]
    public int id;
    public Vector3 position;
    public List<int> list;
}

