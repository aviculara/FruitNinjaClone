using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class PlayerPrefsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // when custom editor is added, it overrides default inspector
        //in order to retain the defaults, use:
        base.OnInspectorGUI();
        //or if you don't want to change its ordering, use:
        //DrawDefaultInspector();

        GameManager gmScript = (GameManager)target;

        //gmScript.highscore = EditorGUILayout.IntField("Highscore", gmScript.highscore);

        GUILayout.Label("Editor");
        

        if (GUILayout.Button("Reset Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", gmScript.highscore);
        }
        /*

        GameManager script = (GameManager)target;

        if (GUILayout.Button("Reset PlayerPrefs Variable"))
        {
            PlayerPrefs.DeleteKey("YourVariableKey");
            PlayerPrefs.Save();
            Debug.Log("PlayerPrefs variable reset.");
        }
        */
    }
}
