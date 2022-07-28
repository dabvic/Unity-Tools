using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PopupSingletonHelper : MonoBehaviour
{
    public Popup[] all;
    private void Awake()
    {
        all = GetComponentsInChildren<Popup>(true);
        foreach (Popup popup in all)
        {
            popup.AddRefferenceToDictionary();
        }
    }
}
