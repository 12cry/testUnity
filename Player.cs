using System.Collections;
using System.Collections.Generic;
using testUnity;
using UnityEngine;

public class Player : MonoBehaviour {
    public int x { get; set; }
    public int z { get; set; }
    public bool canBeAttacked = false;
    public bool isAI = false;
    public Team team;
    public PlayerState state = PlayerState.Finish;
    void Awake () {
        x = int.Parse (transform.position.x.ToString ());
        z = int.Parse (transform.position.z.ToString ());
    }

    public void init () {
        GetComponent<Renderer> ().material.color = getTeamColor ();
        DialTheCloud();
        team.playerList.Add(this);
    }
    Color getTeamColor () {
        Color color = Color.white;
        if (team.id == 1) {
            color = Color.red;
        }
        return color;
    }
    void DialTheCloud () {
        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {
                if (x + i < 0 || x + i >= Land.instance.maxX || z + j < 0 || z + j >= Land.instance.maxZ || (i == 0 & j == 0)) {
                    continue;
                }
                team.visualTile[x + i, z + j] = true;
            }
        }
    }
    void Update () {

        if (state == PlayerState.Finish) {
            return;
        }
        if (state == PlayerState.Ready) {
            state = PlayerState.Playing;
            autoRun ();
        }
        if (state == PlayerState.AfterMove) {
            DialTheCloud();
            Static.clean ();
            showAttackable ();

            if (isAI) {
                if (Static.attackablePlayerList.Count > 0) {
                    state = PlayerState.Attacking;
                    attack (Static.attackablePlayerList[0]);
                }
                Static.clean ();
                Static.currentPlayerState = PlayerState.Finish;
            }
            state = PlayerState.Finish;
        }
    }
    private void OnMouseDown () {

        if (canBeAttacked) {
            attack (this);
            Static.clean ();
            return;
        }
        if (isAI) {
            return;
        }
        if (Static.currentSelectedPlayer == this) {
            return;
        }
        Static.currentSelectedPlayer = this;
        showAttackable ();
        showMoveable ();
    }
    public void autoRun () {
        for (int circle = 1; circle < Mathf.Max (Land.instance.maxX, Land.instance.maxZ); circle++) {
            for (int i = -circle; i < circle; i++) {
                for (int j = -circle; j < circle; j++) {
                    if (x + i < 0 || x + i >= Land.instance.maxX || z + j < 0 || z + j >= Land.instance.maxZ || (i == 0 & j == 0)) {
                        continue;
                    }

                    if (Mathf.Abs (i) == circle || Mathf.Abs (j) == circle) {
                        Player player = Static.findPlayer (x + i, z + j);
                        if (player != null && player.team != team) {
                            showAttackable ();
                            showMoveable ();
                            if (player.canBeAttacked) {
                                attack (player);
                                Static.clean ();
                            } else {
                                Tile tile = getShortestDistanceTile (player);
                                move (tile);
                            }
                            return;

                        }
                    }
                }
            }
        }
        showMoveable ();
        move (getRandomTile ());
    }
    public void move (Tile tile) {
        state = PlayerState.Moving;
        iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (tile.x, 0, tile.z), "time", 1, "oncomplete", "afterMove"));
        // iTween.MoveTo (gameObject, new Vector3 (tile.x, 0, tile.z), 0.2f);
        this.x = tile.x;
        this.z = tile.z;
    }
    void afterMove () {
        state = PlayerState.AfterMove;
    }

    Tile getRandomTile () {
        return Static.moveableTileList[0];
    }
    Tile getShortestDistanceTile (Player player) {
        float distance = Mathf.Infinity;
        Tile result = null;
        foreach (Tile tile in Static.moveableTileList) {
            float distance2 = (tile.transform.position - player.transform.position).sqrMagnitude;
            if (distance2 < distance) {
                result = tile;
                distance = distance2;
            }
        }
        return result;
    }
    void attack (Player player) {
        Debug.Log (player.name);
        player.gameObject.SetActive (false);
        Object.Destroy (player);
    }
    public void showAttackable () {
        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {

                if (x + i < 0 || x + i >= Land.instance.maxX || z + j < 0 || z + j >= Land.instance.maxZ || (i == 0 & j == 0)) {
                    continue;
                }

                Player player = Static.findPlayer (x + i, z + j);
                if (player != null && player.team != Static.currentTeam) {
                    player.enableAttack ();
                    Static.attackablePlayerList.Add (player);
                }
            }
        }
    }

    
    void showMoveable () {
        Tile[, ] tiles = Static.tiles;
        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {

                if (x + i < 0 || x + i >= Land.instance.maxX || z + j < 0 || z + j >= Land.instance.maxZ || (i == 0 & j == 0)) {
                    continue;
                }
                Tile tile = tiles[x + i, z + j];
                Static.moveableTileList.Add (tile);
                tile.enableMove ();

            }
        }
    }

    public void disableAttack () {
        canBeAttacked = false;
    }
    public void enableAttack () {
        this.GetComponent<MeshRenderer> ().sharedMaterial = Static.getMbMaterial ();
        canBeAttacked = true;
    }

}