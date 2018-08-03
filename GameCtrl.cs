using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl
{
    public static Tile currentSelectedTile { get; set; }
    public static Player currentSelectedPlayer { get; set; }
    public static List<Tile> moveableTileList = new List<Tile>();

    public static void cleanTiles()
    {
        foreach (Tile tile in moveableTileList)
        {
            tile.disableMove();
        }
        moveableTileList.Clear();
    }
}
