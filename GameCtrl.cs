using System.Collections;
using System.Collections.Generic;
using testUnity;
using UnityEngine;

public class GameCtrl {
    public static Tile currentSelectedTile { get; set; }
    public static Player currentSelectedPlayer { get; set; }
    public static List<Tile> moveableTileList = new List<Tile> ();
    public static List<Player> attackablePlayerList = new List<Player> ();
    public static int totalNumberOfTeam = 3;
    public static int currentTeam = 2;
    public static GameState currentGameState = GameState.Normal;
    public static AIState currentAIState = AIState.Finish;


    public static void clean(){
        cleanAttachablePlayerList();
        cleanMoveableTileList();
    }
    public static void cleanMoveableTileList () {
        foreach (Tile tile in moveableTileList) {
            tile.disableMove ();
        }
        moveableTileList.Clear ();
    }

    public static void cleanAttachablePlayerList () {
        foreach (Player player in attackablePlayerList) {
            player.disableAttack ();
        }
        attackablePlayerList.Clear ();
    }
}