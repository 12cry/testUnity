
using System;
using UnityEngine;

public class t1 : MonoBehaviour {

    public BuildInfoUI buildInfoUI;
    public int type;
    void Start () {
        new System.Random().Next();
    }
	
	void Update () {

    }
    private void OnMouseDown()
    {
        GameCtrl.currentSelectedTile.setTileType(type);
    }


        //按钮文字

        public string text;

        //大小位置

        public Rect position;

        //深度

        public int depth;

        //颜色及透明度

        public Color color = Color.white;

        //是否启用

        public bool isEnabled = true;

        //样式设置

        public GUIStyle style;

        void OnGUI(){
        //Debug.Log("------");
        PlayerPrefs p;
        GUI.Label(new Rect(30, 10, 100, 200), "zzzzzz");
        GUI.Label(new Rect(30, Screen.height - 50, 100, 200), "zzzzzz");
        GUI.Label(new Rect(Screen.width - 50, Screen.height - 50, 100, 200), "zzzzzz");
        GUI.Label(new Rect(Screen.width - 50, 10, 100, 200), "zzzzzz");


        GUI.Label(new Rect(30, 30, 100, 200), "Button");
        GUI.Button(new Rect(30, 50, 50, 50), "这个是一个按钮");
        GUI.Button(new Rect(90, 50, 50, 50), text);
        //带图片带文字的按钮
        GUIContent guic = new GUIContent("按钮", text);
        GUI.Button(new Rect(150, 50, 50, 50), guic);
        //按键从上往下排 自动排序
        if (GUILayout.Button("1"))
            Debug.Log("1");
        if (GUILayout.Button("2"))
            Debug.Log("2");
        if (GUILayout.Button("3"))
            Debug.Log("3");
        if (GUILayout.Button("4"))
            Debug.Log("4");
        if (GUILayout.Button("5"))
            Debug.Log("5");
        if (GUILayout.Button("6"))
            Debug.Log("6");
        if (GUILayout.Button("7"))
            Debug.Log("7");
        if (GUILayout.Button("8"))
            Debug.Log("8");
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
