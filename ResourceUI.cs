using System.Collections;
using System.Collections.Generic;
using Cry.Common;
using testUnity;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : Singleton<ResourceUI> {

	public Text moneyValueText;
	
	protected override void Awake()
	{
		base.Awake();
	}

	public void init(){
		moneyValueText.text = Static.teamDic[0].money.ToString();
	}
}
