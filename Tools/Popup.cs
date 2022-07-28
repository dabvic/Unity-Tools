using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public string popupName = "";
    public float animationTime = .5f;
    public bool deactivateOnStart = true;

    protected float startScale = 0;
    protected float targetScale = 1;

    protected int direction;

    protected float currentAnimationTime;

    public float lastCloseTime;

    public static Dictionary<string, Popup> popupsDict = new Dictionary<string, Popup>();

    public void AddRefferenceToDictionary()
    {
        if (popupName == "")
        {
            return;
        }
        if (popupsDict.ContainsKey(popupName))
        {
            popupsDict[popupName] = this;
        }
        else
        {
            popupsDict.Add(popupName, this);
        }
    }

    public static void Show(string popupName)
    {
        if (popupsDict.ContainsKey(popupName))
        {
            popupsDict[popupName].Show();
        }
#if UNITY_EDITOR
        else
        {
            Debug.LogError(popupName + " not found");
        }
#endif
    }

    public static void Hide(string popupName)
    {
        if (popupsDict.ContainsKey(popupName))
            popupsDict[popupName].Hide();
    }

    public static void HideImmediate(string popupName)
    {
        if (popupsDict.ContainsKey(popupName))
            popupsDict[popupName].HideImmediate();
    }

    public void Show()
    {
        lastCloseTime = Time.unscaledTime;
        gameObject.SetActive(true);
        currentAnimationTime = 0f;
        direction = 1;
    }

    public void Hide()
    {
        if (lastCloseTime + animationTime > Time.unscaledTime)
        {
            return;
        }
        lastCloseTime = Time.unscaledTime;

        currentAnimationTime = 1f;
        direction = -1;
    }

    public void HideImmediate()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {

        if (direction == 1)
        {
            currentAnimationTime += Time.unscaledDeltaTime / animationTime * direction;
            currentAnimationTime = Mathf.Clamp01(currentAnimationTime);
            transform.localScale = Vector3.one * EasingFunctions.EaseOutElastic(startScale, targetScale, currentAnimationTime);
        }
        else
        {
            currentAnimationTime += Time.unscaledDeltaTime / animationTime * direction;
            currentAnimationTime = Mathf.Clamp01(currentAnimationTime);
            transform.localScale = Vector3.one * EasingFunctions.EaseInQuint(startScale, targetScale, currentAnimationTime);
        }

        //deactivate
        if (targetScale == 0 || transform.localScale.x <= 0)
        {
            gameObject.SetActive(false);
        }

    }
}
