using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TestClass))]
public class TestClassEditor : Editor
{
    SerializedProperty intField;
    SerializedProperty stringField;

    void OnEnable()
    {
        //获取指定字段
        intField = serializedObject.FindProperty("intData");
        stringField = serializedObject.FindProperty("stringData");
    }

    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();
        EditorGUILayout.IntSlider(intField, 0, 100, new GUIContent("initData"));
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(stringField);
        if (GUILayout.Button("Select"))
        {
            stringField.stringValue = EditorUtility.OpenFilePanel("", Application.dataPath, "");
        }
        EditorGUILayout.EndHorizontal();

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        //需要在OnInspectorGUI之前修改属性，否则无法修改值
        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}