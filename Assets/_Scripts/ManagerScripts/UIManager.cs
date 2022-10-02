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

    int levelCount = 0;
    private void Start()
    {
        btnPlay.onClick.AddListener(HideGameObject);
        btnRateUs.onClick.AddListener(RateApp);
        btnRestore.onClick.AddListener(RestoreApp);
        btnMore.onClick.AddListener(MoreApps);
        btnNext.onClick.AddListener(LoadNextLevel);
        btnHome.onClick.AddListener(LoadHome);
    }

    private void LoadHome()
    {
        levelCount = 0;
        EventHandler.Instance.InvokeOnButtonClickSound();
        //GameManager.Instance.Home();
        GameManager.Instance.Next();

    }

    private void LoadNextLevel()
    {
        Debug.Log("Click on Next Button");
        EventHandler.Instance.InvokeOnButtonClickSound();
        if (levelCount < GameManager.Instance.Body.Length)
        {
            levelCount++;
            EventHandler.Instance.InvokeOnLoadLevel(levelCount);   
        }
        else
        {
            GameManager.Instance.DeActivateAllLevels();
            GameManager.Instance.Next();
        }
        print(levelCount + " in Load Next Level");
    }

    public void LoadPreviousLevel()
    {
        Debug.Log("Click on Previous Button " + levelCount);
        EventHandler.Instance.InvokeOnButtonClickSound();
        levelCount--;
        if (levelCount > 0)
        {
            EventHandler.Instance.InvokeOnLoadLevel(levelCount);
        }
        else
        {
            GameManager.Instance.Back();
        }
        print(levelCount + " in Load Previous Level");

    }

    public void ShowInterestratialAd()
    {
        EventHandler.Instance.InvokeOnShowInterstitialAd();
    }

    public void HideGameObject()
    {
        Debug.Log("Hide Game Object Method");
        EventHandler.Instance.InvokeOnButtonClickSound();
        EventHandler.Instance.InvokeOnNextScene();

        // Load Level
        LoadNextLevel();
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
