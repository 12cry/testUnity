using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    public int x;
    public int y;
    public int size = 1;
    public Tile tile;

    protected virtual void Awake()
    {
    }
    void Start()
    {
        init();
    }

    void init()
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Vector3 v = getV(i, j);
                Tile newTile = Instantiate(tile);
                newTile.transform.parent = transform;
                newTile.transform.localPosition = v;
                //newTile.transform.localRotation = Quaternion.identity;
                // newTile.setTileType(Random.Range(0, 2));
            }
        }
    }

    Vector3 getV(int i, int j)
    {
        Vector3 v = new Vector3(i, 0, j);
        return v;
    }
    void OnDrawGizmos()
    {
        Color prevCol = Gizmos.color;
        Gizmos.color = Color.cyan;

        Matrix4x4 originalMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;

        for (int j = 0; j < y; j++)
        {
            for (int i = 0; i < x; i++)
            {
                var position = getV(i, j);
                Gizmos.DrawWireCube(position, new Vector3(size, 0, size));
            }
        }
        Gizmos.matrix = originalMatrix;
        Gizmos.color = prevCol;

    }

    public static void Main(string[] args)
    {
        Land land = new Land();        
        Debug.Log("main");
        Debug.Log(Random.Range(1, 5));
    }

    public void test(){
        
    }
}
