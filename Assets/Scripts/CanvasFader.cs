using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

[RequireComponent(typeof(CanvasGroup))]

public class CanvasFader : MonoBehaviour
{
    [SerializeField] private bool startFadedOut;
    [SerializeField] private float fadeInTime = 1f;
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private bool interactable = true;
    private CanvasGroup canvasGroup = null;
    private bool originalInteractableState = false;
    private float? fadeTime = null;
    private float totalFadeTime;
    private bool fadeIn = true;

    public float FadedValue { get { return fadeTime.HasValue ? (fadeTime.Value / totalFadeTime) : (fadeIn ? 1f : 0f); }}

    public bool IsShown { get { return fadeIn; } }

    // Start is called before the first frame update
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        originalInteractableState = canvasGroup.interactable;

        if(startFadedOut)
        {
            Hide(0f);
        }
        else
        {
            Show(0f);
        }
    }

    public void Show(float time)
    {
        Set(time, true);
    }

    public void Hide(float time)
    {
        Set(time, false);
    }

    private void Set(float fadeTime, bool value)
    {
        this.fadeTime = fadeTime;
        totalFadeTime = fadeTime;
        fadeIn = value;
        canvasGroup.interactable = interactable? value : originalInteractableState;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeTime.HasValue)
        {
            if(Mathf.Approximately(totalFadeTime, 0f))
            {
                fadeTime = null;
                canvasGroup.alpha = fadeIn ? 1f : 0f;
            }
            else
            {
                canvasGroup.alpha = Mathf.Lerp(fadeIn? 1f : 0f, fadeIn? 0f : 1f, fadeTime.Value/totalFadeTime);
                fadeTime -= Time.deltaTime;
                if(fadeTime < 0f)
                {
                    fadeTime = null;
                    canvasGroup.alpha = fadeIn ? 1f : 0f;
                }

            }
        }
    }
}
