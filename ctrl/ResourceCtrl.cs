using Cry.Common;
using testUnity.common;
using UnityEngine.UI;

namespace testUnity.ctrl {
	public class ResourceCtrl : Singleton<ResourceCtrl> {

		public Text moneyValueText;

		protected override void Awake () {
			base.Awake ();
		}

		public void init () {
			moneyValueText.text = StaticVar.teamDic[0].money.ToString ();
		}
	}
}