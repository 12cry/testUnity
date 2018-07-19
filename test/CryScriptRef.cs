using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CryScriptRef : EditorWindow
{


    //[MenuItem("Assets/Find All Reference")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CryScriptRef));
    }
    
    //[MenuItem("Assets/Check Prefab Use ?")]
    private static void OnSearchForReferences()
    {
        if (Selection.gameObjects.Length != 1)
        {
            return;
        }

        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                EditorSceneManager.OpenScene(scene.path);
                GameObject[] gos = (GameObject[])FindObjectsOfType(typeof(GameObject));
                foreach (GameObject go in gos)
                {
                    //判断GameObject是否为一个Prefab的引用
                    if (PrefabUtility.GetPrefabType(go) == PrefabType.PrefabInstance)
                    {
                        UnityEngine.Object parentObject = PrefabUtility.GetPrefabParent(go);
                        string path = AssetDatabase.GetAssetPath(parentObject);
                        if (path == AssetDatabase.GetAssetPath(Selection.activeGameObject))
                        {
                            Debug.Log(scene.path + "  " + GetGameObjectPath(go));
                        }
                    }
                }
            }
        }
    }
    public static string GetGameObjectPath(GameObject obj)
    {
        string path = "/" + obj.name;
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = "/" + obj.name + path;
        }
        return path;
    }
}
