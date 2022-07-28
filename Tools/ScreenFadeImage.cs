using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeImage : Singleton<ScreenFadeImage>
{
    public Image image;


    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        image.enabled = true;
        while (image.color.a < 1)
        {
            Color current = image.color;
            current.a += Time.deltaTime;
            image.color = current;
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        while (singleton.image.color.a > 0)
        {
            Color current = singleton.image.color;
            current.a -= Time.deltaTime;
            singleton.image.color = current;
            yield return null;
        }
        singleton.image.enabled = false;

    }

}
