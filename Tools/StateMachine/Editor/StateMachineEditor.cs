using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Tools.StateMachine
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(StateMachine))]
    public class StateMachineEditor : Editor
    {
        protected ReorderableList _list;
        protected SerializedProperty stateMachineActive;
        protected SerializedProperty timeInThisState;
        protected SerializedProperty _target;

        protected virtual void OnEnable()
        {
            _list = new ReorderableList(serializedObject.FindProperty("States"));
            _list.elementNameProperty = "States";
            _list.elementDisplayType = ReorderableList.ElementDisplayType.Expandable;

            stateMachineActive = serializedObject.FindProperty("stateMachineActive");
            timeInThisState = serializedObject.FindProperty("timeInThisState");
            _target = serializedObject.FindProperty("Target");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _list.DoLayoutList();
            EditorGUILayout.PropertyField(stateMachineActive);
            EditorGUILayout.PropertyField(timeInThisState);
            EditorGUILayout.PropertyField(_target);
            serializedObject.ApplyModifiedProperties();

            StateMachine brain = (StateMachine)target;
            if (brain.CurrentState != null)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Current State", brain.CurrentState.StateName);
            }
        }
    }
}
