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
    Button btnShare;
    [SerializeField]
    Button GamePlayArea1;
    
    


    private void Start()
    {
        btnPlay.onClick.AddListener(HideGameObject);
        btnRateUs.onClick.AddListener(RateApp);
        btnRestore.onClick.AddListener(RestoreApp);
        btnMore.onClick.AddListener(MoreApps);
        btnShare.onClick.AddListener(ShareApp);

        GamePlayArea1.onClick.AddListener(HideGameObject);
        GamePlayArea1.onClick.AddListener(()=>LoadLevel(1));
        
    }

    private void LoadLevel(int i)=>EventHandler.Instance.InvokeOnLoadLevel(i);
    

    public void ShowInterestratialAd() => EventHandler.Instance.InvokeOnShowInterstitialAd();

    public void HideGameObject()
    {
        Debug.Log("Hide Game Object Method");
        EventHandler.Instance.InvokeOnButtonClickSound();
        EventHandler.Instance.InvokeOnNextScene();    
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

    public void ShareApp()
    {
        EventHandler.Instance.InvokeOnButtonClickSound();
        EventHandler.Instance.InvokeOnShareApp();
    }
}
