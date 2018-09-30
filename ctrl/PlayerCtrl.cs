using System.Collections;
using System.Collections.Generic;
using testUnity;
using testUnity.common;
using testUnity.constant;
using testUnity.model;
using testUnity.service;
using UnityEngine;

namespace testUnity.ctrl {
    public class PlayerCtrl : MonoBehaviour {
        public Player player;
        void Awake () {
            player = new Player ();
            player.x = int.Parse (transform.position.x.ToString ());
            player.z = int.Parse (transform.position.z.ToString ());
        }
        void Update () {

            if (player.state == PlayerState.Finish) {
                return;
            }
            if (player.state == PlayerState.Ready) {
                player.state = PlayerState.Playing;
                player.autoRun ();
            }
            if (player.state == PlayerState.AfterMove) {
                Tool.DialTheCloud (player.x, player.z, player.team);
                Static.clean ();
                player.showAttackable ();

                if (player.team.isAI) {
                    if (Static.attackablePlayerList.Count > 0) {
                        player.state = PlayerState.Attacking;
                        player.attack (Static.attackablePlayerList[0]);
                        player.state = PlayerState.Finish;
                    }
                    Static.clean ();
                }
            }
        }
        void OnMouseDown () {

            if (player.canBeAttacked) {
                Static.currentSelectedPlayer.attack (player);
                Static.clean ();
                Static.currentSelectedPlayer.state = PlayerState.Finish;
                return;
            }
            if (player.team.isAI) {
                return;
            }
            if (Static.currentSelectedPlayer == player) {
                return;
            }
            Static.currentSelectedPlayer = player;

            if (player.state == PlayerState.Playing) {
                player.showMoveable ();
                player.showAttackable ();
            } else if (player.state == PlayerState.AfterMove) {
                player.showAttackable ();
            }
        }
    }

}