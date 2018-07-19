using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t1 : MonoBehaviour {

    public BuildInfoUI buildInfoUI;
    public int type;
    void Start () {
		
	}
	
	void Update () {

    }
    private void OnMouseDown()
    {
        GameCtrl.currentSelectedTile.setTileType(type);
        GameCtrl.hideBuildInfoUI();
    }









    private void OnMouseEnter()
    {
        Debug.Log("enter");
    }
    private void OnMouseDrag()
    {
        Debug.Log("deag");
    }

    public void f1()
    {
        Debug.Log("f1");
    }

    public void f2()
    {
        Debug.Log("f2");
    }
}
