using System.Collections;
using System.Collections.Generic;
using testUnity;
using UnityEngine;

public class Player : MonoBehaviour {
    public int x { get; set; }
    public int z { get; set; }
    public bool canAttack = false;
    public bool isAI = false;
    public int civID;
    public AIState aIState = AIState.Finish;
    Player attackTarget;
    void Awake () {
        x = int.Parse (transform.position.x.ToString ());
        z = int.Parse (transform.position.z.ToString ());
    }
    void Update () {
        if (aIState == AIState.Ready) {
            aIState = AIState.Playing;
            autoRun ();
        }
        if (aIState == AIState.AfterMove) {
            GameCtrl.clean ();
            showAttackable ();

            if (isAI) {
                if (GameCtrl.attackablePlayerList.Count > 0) {
                    aIState = AIState.Attacking;
                    attack (GameCtrl.attackablePlayerList[0]);
                }
                GameCtrl.clean ();
                GameCtrl.currentAIState = AIState.Finish;
            }
            aIState = AIState.Finish;
        }
    }
    private void OnMouseDown () {
        if (canAttack) {
            attack (this);
            GameCtrl.clean ();
            return;
        }
        if (GameCtrl.currentSelectedPlayer == this) {
            return;
        }
        GameCtrl.currentSelectedPlayer = this;
        showAttackable ();
        showMoveable ();
    }
    public void autoRun () {
        Debug.Log ("autoRun-----");
        for (int circle = 1; circle < Mathf.Max (Land.instance.x, Land.instance.z); circle++) {
            for (int i = -circle; i < circle; i++) {
                for (int j = -circle; j < circle; j++) {
                    if (x + i < 0 || x + i >= Land.instance.x || z + j < 0 || z + j >= Land.instance.z || (i == 0 & j == 0)) {
                        continue;
                    }

                    if (Mathf.Abs (i) == circle || Mathf.Abs (j) == circle) {
                        Player player = findPlayer (x + i, z + j);
                        if (player != null && player.civID != civID) {
                            showAttackable ();
                            showMoveable ();
                            if (player.canAttack) {
                                attack (player);
                                GameCtrl.clean ();
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
        Debug.Log (tile.x);
        aIState = AIState.Moving;
        iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (tile.x, 0, tile.z), "time", 1, "oncomplete", "afterMove"));
        // iTween.MoveTo (gameObject, new Vector3 (tile.x, 0, tile.z), 0.2f);
        this.x = tile.x;
        this.z = tile.z;
    }
    void afterMove () {
        aIState = AIState.AfterMove;
    }

    Tile getRandomTile () {
        return GameCtrl.moveableTileList[0];
    }
    Tile getShortestDistanceTile (Player player) {
        float distance = Mathf.Infinity;
        Tile result = null;
        foreach (Tile tile in GameCtrl.moveableTileList) {
            float distance2 = (tile.transform.position - player.transform.position).sqrMagnitude;
            if (distance2 < distance) {
                result = tile;
                distance = distance2;
            }
        }
        return result;
    }
    void attack (Player player) {
        player.gameObject.SetActive (false);
        Object.Destroy (player);
    }
    public void showAttackable () {
        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {

                if (x + i < 0 || x + i >= Land.instance.x || z + j < 0 || z + j >= Land.instance.z || (i == 0 & j == 0)) {
                    continue;
                }

                Player player = findPlayer (x + i, z + j);
                if (player != null && player.civID != GameCtrl.currentCivID) {
                    player.enableAttack ();
                    GameCtrl.attackablePlayerList.Add (player);
                }
            }
        }
    }

    Player findPlayer (int i, int j) {
        Player player = null;
        RaycastHit hit;
        Vector3 pos = Camera.main.WorldToScreenPoint (new Vector3 (i, 0, j));
        Ray ray = Camera.main.ScreenPointToRay (pos);

        if (Physics.Raycast (ray, out hit)) {
            player = hit.collider.GetComponent<Player> ();
            if (player != null) {
                Debug.DrawLine (ray.origin, hit.point, Color.red, 200);

            }
        }
        return player;
    }
    void showMoveable () {
        Tile[, ] tiles = Land.instance.tiles;
        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {

                if (x + i < 0 || x + i >= Land.instance.x || z + j < 0 || z + j >= Land.instance.z || (i == 0 & j == 0)) {
                    continue;
                }
                Tile tile = tiles[x + i, z + j];
                GameCtrl.moveableTileList.Add (tile);
                tile.enableMove ();

            }
        }
    }

    public void disableAttack () {
        canAttack = false;
    }
    public void enableAttack () {
        canAttack = true;
    }

}