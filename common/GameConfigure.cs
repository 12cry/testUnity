using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cry.Common;
using testUnity.ctrl;
using testUnity.model;
using UnityEngine;

public class GameConfigure : Singleton<GameConfigure> {
    public int landColumn;
    public int landRow;

    public BuildLibrary buildLibrary;
    
    public BuildButtonCtrl buildButtonCtrlPrefab;
    public PlayerCtrl playerCtrlPrefab;
    public TileCtrl tileCtrlPrefab;

    protected override void Awake () {
        base.Awake ();
        init ();

    }

    void init () {

    }

}