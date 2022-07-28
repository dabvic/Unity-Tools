using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScreenFadeImage))]
public class ScreenFadeImageEditor : Editor
{

    private ScreenFadeImage mono => target as ScreenFadeImage;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Fade In"))
        {
            mono.StartFadeIn();
        }

        if (GUILayout.Button("Fade Out"))
        {
            mono.StartFadeOut();
        }
    }
}
