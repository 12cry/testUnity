using System.Collections;
using System.Collections.Generic;
using testUnity;
using testUnity.common;
using testUnity.constant;
using testUnity.script.model;
using UnityEngine;

namespace testUnity.ctrl {
    public class PlayerCtrl : MonoBehaviour {
        public Player player;
        void Awake () {
            // player.x = int.Parse (transform.position.x.ToString ());
            // player.z = int.Parse (transform.position.z.ToString ());
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
                Tool.clean ();
                player.showAttackable ();

                if (player.team.isAI) {
                    if (StaticVar.attackablePlayerList.Count > 0) {
                        player.state = PlayerState.Attacking;
                        player.attack (StaticVar.attackablePlayerList[0]);
                        player.state = PlayerState.Finish;
                    }
                    Tool.clean ();
                }
            }
        }
        void OnMouseDown () {

            if (player.canBeAttacked) {
                StaticVar.currentSelectedPlayer.attack (player);
                Tool.clean ();
                StaticVar.currentSelectedPlayer.state = PlayerState.Finish;
                return;
            }
            if (player.team.isAI) {
                return;
            }
            if (StaticVar.currentSelectedPlayer == player) {
                return;
            }
            StaticVar.currentSelectedPlayer = player;

            if (player.state == PlayerState.Playing) {
                player.showMoveable ();
                player.showAttackable ();
            } else if (player.state == PlayerState.AfterMove) {
                player.showAttackable ();
            }
        }
    }

}