using UnityEngine;
using UnityEngine.UI;

namespace testUnity.script.model {
    public class ResourcePanel {
        public Text moneyValueText;
        public void init () {
            moneyValueText = GameObject.Find ("MoneyValue").gameObject.GetComponent<Text>();
            setMoneryValue (Game.instance.teamDic[0].money.ToString ());
        }

        public void setMoneryValue (string money) {
            moneyValueText.text = money;
        }
    }
}