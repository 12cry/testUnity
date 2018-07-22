﻿using Cry.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildInfoUI : Singleton<BuildInfoUI> {

    
    protected override void Awake()
    {
        base.Awake();

        init();

    }

    void init()
    {
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
