using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int x { get; set; }
    public int z { get; set; }

    private void OnMouseDown()
    {
        if (GameCtrl.currentSelectedPlayer == this)
        {
            return;
        }
        GameCtrl.currentSelectedPlayer = this;
        showMoveable();
    }
    void showMoveable()
    {
        GameCtrl.moveableTileList.Clear();
        Tile[,] tiles = Land.instance.tiles;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {

                int maxX = Land.instance.x;
                int maxZ = Land.instance.z;

                if (x + i < 0 || x + i > maxX || z + j < 0 || z + j > maxZ)
                {
                    continue;
                }


                Tile tile = tiles[x + i, z + j];
                GameCtrl.moveableTileList.Add(tile);
                tile.enableMove();

            }
        }
    }
    public void move()
    {
        Tile tile = GameCtrl.currentSelectedTile;
        iTween.MoveTo(gameObject, new Vector3(tile.x, 0, tile.z), 0.2f);
    }


}
