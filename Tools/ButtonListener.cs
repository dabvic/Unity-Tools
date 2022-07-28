using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonListener : MonoBehaviour
{
    public Button button;

    public virtual void Awake()
    {
        if(!button)
        {
            button= GetComponent<Button>();
        }
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        TaskOnClick();
        PlaySound();
    }

    public virtual void PlaySound()
    {
        SoundManager.singleton.PlayGui();
    }

    public abstract void TaskOnClick();
}
