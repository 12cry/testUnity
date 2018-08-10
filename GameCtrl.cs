using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl
{
    public static Tile currentSelectedTile { get; set; }
    public static Player currentSelectedPlayer { get; set; }
    public static List<Tile> moveableTileList = new List<Tile>();
    public static List<Player> attackablePlayerList = new List<Player>();

    public static void cleanMoveableTileList()
    {
        foreach (Tile tile in moveableTileList)
        {
            tile.disableMove();
        }
        moveableTileList.Clear();
    }

    public static void cleanAttachablePlayerList()
    {
        foreach (Player player in attackablePlayerList)
        {
            player.disableAttack();
        }
        attackablePlayerList.Clear();
    }
}
