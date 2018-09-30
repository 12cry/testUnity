using testUnity.common;
using UnityEngine.UI;

namespace testUnity.model {
    public class BuildButton {
        public string name;
        // public Button button;
        public Text text;
        public Builder builder;

        public void reduceMoney () {
            Team team = StaticVar.currentTeam;
            team.money -= builder.money;
            if (!team.isAI) {
                ResourceUI.instance.moneyValueText.text = team.money.ToString ();
            }
        }
    }
}