using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    CanvasGroup canvasGroup;
    float fadeTime = 1.0f;

    public static bool isFadeInRunning = false;
    public static bool isFadeOutRunning = false;

    private void Awake()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        if (isFadeInRunning == true)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += fadeTime * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    isFadeInRunning = false;
                }
            }
        }
        if (isFadeOutRunning == true)
        {
            if (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= fadeTime * Time.deltaTime;
                if (canvasGroup.alpha <= 0)
                {
                    isFadeOutRunning = false;
                }
            }
        }
    }
    public void DoFadeIn()
    {
        isFadeInRunning = true;
    }
    public void DoFadeOut()
    {
        isFadeOutRunning = true;
    }
    /*public void DoFadeIn()
    {
        if (canvasGroup.alpha < 1)
        {
            isFadeInRunning = true;
            canvasGroup.alpha = Mathf.MoveTowards(0, 1, DoorPortal.teleportTime * Time.deltaTime);
        }
        isFadeInRunning = false;
        canvasGroup.interactable = false;
        Debug.Log("Fade In completed");
    }

    public void DoFadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            isFadeOutRunning = true;
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha -= Mathf.Lerp(1, 0, timeElapsed / DoorPortal.teleportTime);
        }
        isFadeOutRunning = false;
        canvasGroup.interactable = false;
        Debug.Log("Fade Out completed");
    }*/
}
