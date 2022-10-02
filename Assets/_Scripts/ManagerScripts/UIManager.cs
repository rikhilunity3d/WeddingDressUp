using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class UIManager : GenericSingleton<UIManager> 
{
    [SerializeField]
    Button btnPlay;
    [SerializeField]
    Button btnRateUs;
    [SerializeField]
    Button btnRestore;
    [SerializeField]
    Button btnMore;
    [SerializeField]
    Button btnNext;

    [SerializeField]
    Button btnHome;

    int levelCount = 1;
    private void Start()
    {
        btnPlay.onClick.AddListener(HideGameObject);
        btnRateUs.onClick.AddListener(RateApp);
        btnRestore.onClick.AddListener(RestoreApp);
        btnMore.onClick.AddListener(MoreApps);
        btnNext.onClick.AddListener(LoadLevel);
        btnHome.onClick.AddListener(LoadHome);
    }

    private void LoadHome()
    {
        EventHandler.Instance.InvokeOnButtonClickSound();
        GameManager.Instance.Home();
    }

    public void LoadLevel()
    {
        Debug.Log("Click on NextButton");
        LoadNextLevel(levelCount);
    }
    public void LoadPreviousLevel()
    {
        Debug.Log("Click on PreviousButton");
        LoadPreviousLevel(levelCount);
    }

    private void LoadNextLevel(int i) {
        EventHandler.Instance.InvokeOnButtonClickSound();
        if (GameManager.Instance.Body.Length>=i)
        {
            EventHandler.Instance.InvokeOnLoadLevel(i);
            i++;
            levelCount = i;
        }
        else
        {
            GameManager.Instance.Next();
        }
    }

    private void LoadPreviousLevel(int i)
    {
        EventHandler.Instance.InvokeOnButtonClickSound();
        if (i>0)
        {
            i--;
            levelCount = i;
            EventHandler.Instance.InvokeOnLoadLevel(i);
        }
        else
        {
            GameManager.Instance.Back();
        }
    }

    public void ShowInterestratialAd() {
        EventHandler.Instance.InvokeOnShowInterstitialAd();
            }

    public void HideGameObject()
    {
        Debug.Log("Hide Game Object Method");
        EventHandler.Instance.InvokeOnButtonClickSound();
        EventHandler.Instance.InvokeOnNextScene();

        // Load Level
        LoadLevel();
    }

    public void RateApp()
    {
        EventHandler.Instance.InvokeOnButtonClickSound();
        EventHandler.Instance.InvokeOnRateApp();
    }

    public void RestoreApp()
    {
        EventHandler.Instance.InvokeOnButtonClickSound();
        EventHandler.Instance.InvokeOnRestoreApp();
    }

    public void MoreApps()
    {
        EventHandler.Instance.InvokeOnButtonClickSound();
        EventHandler.Instance.InvokeOnMoreApps();
    }
}
