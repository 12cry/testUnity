using System.Collections;
using System.Collections.Generic;
using Cry.Common;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : Singleton<ResourceUI> {

	public Text moneyValueText;
	public int moneyValue = 10;
	
	protected override void Awake()
	{
		base.Awake();
		moneyValueText.text = moneyValue.ToString();
	}
}
