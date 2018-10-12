using System.Collections;
using System.Collections.Generic;
using testUnity;
using testUnity.common;
using testUnity.constant;
using testUnity.script.model;
using UnityEngine;
namespace testUnity.script.model {
    public class Player {
        public GameObject gameObject;
        public int x { get; set; }
        public int z { get; set; }
        public bool canBeAttacked = false;
        public Team team;
        public PlayerState state = PlayerState.Idle;
        public static List<Player> attackablePlayerList = new List<Player> ();
        public static List<Tile> moveableTileList = new List<Tile> ();

        public void init () {
            gameObject.GetComponent<Renderer> ().material.color = getTeamColor ();
            Tool.DialTheCloud (x, z, team);
            team.playerList.Add (this);
            // StaticVar.currentSelectedPlayer = this;
        }
        public void clean () {
            foreach (Player player in attackablePlayerList) {
                player.disableAttack ();
            }
            attackablePlayerList.Clear ();
            foreach (Tile tile in moveableTileList) {
                tile.disableMove ();
            }
            moveableTileList.Clear ();
        }
        public void autoRun () {
            clean ();
            //查找当前可攻击的
            showAttackable ();
            if (attackablePlayerList != null) {
                attack (attackablePlayerList[0]);
            } else {
                showMoveable ();

                //查找远处可攻击的
                //向远处可攻击移动
                Land land = Game.instance.land;
                for (int circle = 2; circle < Mathf.Max (land.column, land.row); circle++) {
                    for (int i = -circle; i < circle; i++) {
                        for (int j = -circle; j < circle; j++) {
                            if (x + i < 0 || x + i >= land.column || z + j < 0 || z + j >= land.row || (i == 0 & j == 0)) {
                                continue;
                            }

                            Player targetPlayer = Tool.findPlayer (x + i, z + j);
                            if (targetPlayer != null && targetPlayer.team != team) {
                                Tile tile = getShortestDistanceTile (targetPlayer);
                                move (tile);
                                return;
                            }
                        }
                    }
                }
                move (moveableTileList[0]);
            }
            state = PlayerState.Finish;

        }
        public void move (Tile tile) {
            state = PlayerState.Moving;
            // iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (tile.x, 0, tile.z), "time", 1, "oncomplete", "afterMove"));
            // iTween.MoveTo (gameObject, new Vector3 (tile.x, 0, tile.z), 0.2f);
            this.x = tile.x;
            this.z = tile.z;
        }
        void afterMove () {
            Tool.DialTheCloud (x, z, team);
            clean ();
            showAttackable ();

            if (team.isAI) {
                if (attackablePlayerList.Count > 0) {
                    attack (attackablePlayerList[0]);
                }
                clean ();
                state = PlayerState.Finish;
            }else{
                state = PlayerState.AfterMove;
            }

        }

        Tile getShortestDistanceTile (Player player) {
            float distance = Mathf.Infinity;
            Tile result = null;
            foreach (Tile tile in moveableTileList) {
                float distance2 = (tile.gameObject.transform.position - gameObject.transform.position).sqrMagnitude;
                if (distance2 < distance) {
                    result = tile;
                    distance = distance2;
                }
            }
            return result;
        }

        public void attack (Player player) {
            player.gameObject.SetActive (false);
            Object.Destroy (player.gameObject);
            if (team.isAI) {
                state = PlayerState.Finish;
            }
        }
        public void disableAttack () {
            canBeAttacked = false;
        }
        public void enableAttack () {
            gameObject.GetComponent<MeshRenderer> ().sharedMaterial = Tool.getMbMaterial ();
            canBeAttacked = true;
        }

        public void showAttackable () {
            Land land = Game.instance.land;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {

                    if (x + i < 0 || x + i >= land.column || z + j < 0 || z + j >= land.row || (i == 0 & j == 0)) {
                        continue;
                    }
                    Player targetPlayer = Tool.findPlayer (x + i, z + j);
                    if (targetPlayer != null && team != targetPlayer.team) {
                        targetPlayer.enableAttack ();
                        attackablePlayerList.Add (targetPlayer);
                    }
                }
            }
        }

        public void showMoveable () {
            Land land = Game.instance.land;
            Tile[, ] tiles = land.tiles;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (x + i < 0 || x + i >= land.column || z + j < 0 || z + j >= land.row || (i == 0 & j == 0)) {
                        continue;
                    }
                    Tile tile = tiles[x + i, z + j];
                    moveableTileList.Add (tile);
                    tile.enableMove ();
                }
            }
        }

        Color getTeamColor () {
            Color color = Color.white;
            if (team.id == 1) {
                color = Color.red;
            }
            return color;
        }

    }
}