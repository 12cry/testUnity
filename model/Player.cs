using System.Collections;
using System.Collections.Generic;
using testUnity;
using testUnity.common;
using testUnity.constant;
using testUnity.model;
using UnityEngine;
namespace testUnity.model {
    public class Player {
        public int x { get; set; }
        public int z { get; set; }
        public bool canBeAttacked = false;
        public Team team;
        public PlayerState state = PlayerState.Ready;
        public GameObject gameObject;

        public void init () {
            gameObject.GetComponent<Renderer> ().material.color = getTeamColor ();
            Tool.DialTheCloud (x, z, team);
            team.playerList.Add (this);
            // Static.currentSelectedPlayer = this;
        }
        public void autoRun () {
            Land land = ModelRepository.instance.Land;
            for (int circle = 1; circle < Mathf.Max (land.column, land.row); circle++) {
                for (int i = -circle; i < circle; i++) {
                    for (int j = -circle; j < circle; j++) {
                        if (x + i < 0 || x + i >= land.column || z + j < 0 || z + j >= land.row || (i == 0 & j == 0)) {
                            continue;
                        }

                        if (Mathf.Abs (i) == circle || Mathf.Abs (j) == circle) {
                            Player targetPlayer = Static.findPlayer (x + i, z + j);
                            if (targetPlayer != null && targetPlayer.team != team) {
                                showAttackable ();
                                showMoveable ();
                                if (targetPlayer.canBeAttacked) {
                                    attack (targetPlayer);
                                    Static.clean ();
                                } else {
                                    Tile tile = getShortestDistanceTile (targetPlayer);
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
            // iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (tile.x, 0, tile.z), "time", 1, "oncomplete", "afterMove"));
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
                float distance2 = (tile.transform.position - gameObject.transform.position).sqrMagnitude;
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
        }
        public void disableAttack () {
            canBeAttacked = false;
        }
        public void enableAttack () {
            gameObject.GetComponent<MeshRenderer> ().sharedMaterial = Static.getMbMaterial ();
            canBeAttacked = true;
        }

        public void showAttackable () {
            Land land = ModelRepository.instance.Land;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {

                    if (x + i < 0 || x + i >= land.column || z + j < 0 || z + j >= land.row || (i == 0 & j == 0)) {
                        continue;
                    }
                    Player targetPlayer = Static.findPlayer (x + i, z + j);
                    if (targetPlayer != null && team != StaticVar.currentTeam) {
                        enableAttack ();
                        Static.attackablePlayerList.Add (targetPlayer);
                    }
                }
            }
        }

        public void showMoveable () {
            Land land = ModelRepository.instance.Land;
            Tile[, ] tiles = land.tiles;
            for (int i = -1; i <= 1; i++) {
                for (int j = -1; j <= 1; j++) {
                    if (x + i < 0 || x + i >= land.column || z + j < 0 || z + j >= land.row || (i == 0 & j == 0)) {
                        continue;
                    }
                    Tile tile = tiles[x + i, z + j];
                    Static.moveableTileList.Add (tile);
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