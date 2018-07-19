using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cry.Common;

public class GameConfigure : Singleton<GameConfigure>
{
    public BuildableLibrary buildableLibrary;
    public BuildableButtonUI buildableButtonUI;

    protected override void Awake()
    {
        base.Awake();
        init();
    }

    void init()
    {

        foreach (Buildable builder in buildableLibrary.buildableList)
        {
            BuildableButtonUI newBT = Instantiate(buildableButtonUI);
            newBT.text.text = builder.buildName;

        }
    }

}
