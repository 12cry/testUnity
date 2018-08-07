using System.Collections;
using System.Collections.Generic;
using Cry.Common;
using UnityEngine;

public class Land : Singleton<Land>
{
    public int x;
    public int z;
    public int size = 1;
    public Tile tile;
    public Tile[,] tiles;

    protected void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        init();
    }

    void init()
    {
        tiles = new Tile[x, z];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                Vector3 v = getV(i, j);
                Tile newTile = Instantiate(tile);
                newTile.x = i;
                newTile.z = j;
                newTile.transform.parent = transform;
                newTile.transform.localPosition = v;

                // newTile.setTileType(Random.Range(0, 2));
                // GameCtrl.tiles[i][j] = newTile;
                tiles[i, j] = newTile;
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

        for (int j = 0; j < z; j++)
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

    public void test()
    {

    }
}
