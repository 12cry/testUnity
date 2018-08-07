using Cry.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildInfoUI : Singleton<BuildInfoUI>
{
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        int i = 1;
        foreach (Buildable buildable in GameConfigure.instance.buildableLibrary)
        {
            BuildableButtonUI newBT = Instantiate(GameConfigure.instance.buildableButtonUI, transform);
            newBT.buildable = buildable;
            newBT.text.text = buildable.buildName;
            newBT.transform.localPosition = newBT.transform.localPosition + new Vector3(i * 100, 0, 0);
            // newBT.buttonClick += this.build;
            i++;
        }
    }

    // public void build(Buildable buildable)
    // {
    //     Debug.Log("build------");
    //     if(GameCtrl.currentSelectedTile==null){
    //         return ;
    //     }
    //     GameCtrl.currentSelectedTile.setTileType(buildable);
    // }

    public void show()
    {
        GetComponent<Canvas>().enabled = true;
    }
    public void hide()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
