using testUnity.common;
using testUnity.ctrl;
using UnityEngine.UI;

namespace testUnity.script.model {
    public class BuildButton {
        public string name;
        public Builder builder;

        public void reduceMoney () {
            Team team = StaticVar.currentTeam;
            team.money -= builder.money;
            if (!team.isAI) {
                Game.instance.resourcePanel.setMoneryValue (team.money.ToString ());
            }
        }
    }
}