using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cry.Common;
using testUnity;
using UnityEngine;

public class Land : Singleton<Land> {
    public int maxX;
    public int maxZ;
    public int size = 1;
    public Tile tile;

    protected override void Awake () {
        base.Awake ();
    }
    void Start () {
        genLand ();
        init ();
        ResourceUI.instance.init ();
        CameraRig.instance.init (maxX, maxZ);
    }

    void genLand () {
        Static.tiles = new Tile[maxX, maxZ];
        for (int i = 0; i < maxX; i++) {
            for (int j = 0; j < maxZ; j++) {
                Vector3 v = getV (i, j);
                Tile newTile = Instantiate (tile);
                newTile.x = i;
                newTile.z = j;
                newTile.transform.parent = transform;
                newTile.transform.localPosition = v;
                newTile.buildableType = BuildableType.Flat;
                Static.tiles[i, j] = newTile;
            }
        }
    }
    void init () {

        Static.buildableDic = GameConfigure.instance.buildableLibrary.buildableList.ToDictionary (t => t.type);
        Static.buildMoneyDic = GameConfigure.instance.buildableLibrary.buildableList.ToDictionary (t => t.type, t => t.money);

        Team team = new Team ();
        team.id = 0;
        team.isAI = false;
        team.money = 10;
        team.visualTile = new bool[maxX, maxZ];
        Static.teamDic[0] = team;

        team = new Team ();
        team.id = 1;
        team.isAI = true;
        team.money = 10;
        team.visualTile = new bool[maxX, maxZ];
        Static.teamDic[1] = team;

        Dictionary<BuildableType, Buildable> buildableDictionary = Static.buildableDic;
        Static.currentTeam = Static.teamDic[0];
        Static.currentSelectedTile = Static.tiles[Random.Range (1, maxX - 1), Random.Range (1, maxZ - 1)];
        buildableDictionary[BuildableType.City].build ();
        buildableDictionary[BuildableType.Warrior].build ();

        Static.currentTeam = Static.teamDic[1];
        Static.currentSelectedTile = getInitBuildCityTile ();
        buildableDictionary[BuildableType.City].build ();
        buildableDictionary[BuildableType.Warrior].build ();

        Static.currentTeam = Static.teamDic[0];
    }

    Tile getInitBuildCityTile () {

        int x = Random.Range (1, maxX - 1);
        int z = Random.Range (1, maxZ - 1);
        Tile tile = Static.tiles[x, z];

        Tile[, ] tiles = Static.tiles;
        for (int i = -1; i <= 1; i++) {
            for (int j = -1; j <= 1; j++) {
                if (tiles[x + i, z + j].city != null) {
                    return getInitBuildCityTile ();
                }
            }
        }

        return tile;
    }

    Vector3 getV (int i, int j) {
        Vector3 v = new Vector3 (i, 0, j);
        return v;
    }
    void OnDrawGizmos () {
        Color prevCol = Gizmos.color;
        Gizmos.color = Color.cyan;

        Matrix4x4 originalMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;

        for (int j = 0; j < maxZ; j++) {
            for (int i = 0; i < maxX; i++) {
                var position = getV (i, j);
                Gizmos.DrawWireCube (position, new Vector3 (size, 0, size));
            }
        }
        Gizmos.matrix = originalMatrix;
        Gizmos.color = prevCol;

    }

}