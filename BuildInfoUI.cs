﻿using Cry.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildInfoUI : Singleton<BuildInfoUI> {

    
    protected override void Awake()
    {
        base.Awake();


    }
    void Start()
    {
        
        init();
    }

    void init()
    {

        int i=2;
        foreach (Buildable builder in GameConfigure.instance.buildableLibrary)
        {
            BuildableButtonUI newBT = Instantiate(GameConfigure.instance.buildableButtonUI,CanvasCtrl.instance._transform);
            newBT.text.text = builder.buildName;
            newBT.transform.localPosition=newBT.transform.localPosition+new Vector3(0,i*30+20,0);
            i++;
        }
    }


    public void show()
    {
        GetComponent<Canvas>().enabled = true;
    }
    void hide()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
