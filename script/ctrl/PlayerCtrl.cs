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

            if (player.state == PlayerState.Idle) {
                return;
            }
            if (player.state == PlayerState.Running) {
                player.autoRun ();
            }
            
        }
        void OnMouseDown () {

            if (player.canBeAttacked) {
                StaticVar.currentSelectedPlayer.attack (player);
                player.clean ();
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

            if (player.state == PlayerState.Idle) {
                player.showMoveable ();
                player.showAttackable ();
            } else if (player.state == PlayerState.AfterMove) {
                player.showAttackable ();
            }
        }
    }

}