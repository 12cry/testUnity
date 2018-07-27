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

    }

}
