using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Popup))]
public class PopupEditor : Editor
{

    private Popup mono => target as Popup;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Show Popup"))
        {
            mono.Show();
        }

        if (GUILayout.Button("Hide Popup"))
        {
            mono.Hide();
        }
    }
}
