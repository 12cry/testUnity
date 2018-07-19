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
        init();
    }

    void init()
    {


        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Vector3 v = new Vector3(i * 1.1f, 0, j * 1.1f);
                Tile newTile = Instantiate(tile);
                newTile.transform.parent = transform;
                newTile.transform.localPosition = v;
                //newTile.transform.localRotation = Quaternion.identity;

                Random.Range(1, 3);
                newTile.setTileType(0);
            }
        }
    }


    public static void Main(string[] args)
    {
        Debug.Log("main");
        Debug.Log(Random.Range(1, 5));
    }

}
