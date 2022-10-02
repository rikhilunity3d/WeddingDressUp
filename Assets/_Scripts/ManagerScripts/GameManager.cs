///ca-app-pub-8179797674906935~6624229151
using System.Collections;
using UnityEngine;
using System;
using System.IO;

public class GameManager : GenericSingleton<GameManager>
{
    int i=0;

    [SerializeField]
    string iOSRateAppURL;
    [SerializeField]
    string iOSAppStoreURL;
    [SerializeField]
    string androidRateAppURL;
    [SerializeField]
    string playStoreURL;

    [Header("Drag N Drop GameObject Here. Look for similar name in Hierarchy Tab")]
    // GameObject
    [SerializeField] GameObject [] ScreenAreas;

    [Header("Drag N Drop UI Panel Here From Canvas. For Canvas see Hierarchy Tab")]
    //UI Panel
    [SerializeField] GameObject [] UIPanels;

    [SerializeField]SpriteRenderer backgroundImage;

    [SerializeField] GameObject[] body;

    [SerializeField] SpriteRenderer[] levelBgImage;

    [SerializeField]
    Camera cam;

    LevelSetUpScriptableObject LevelSetUpSO;

    public GameObject[] Body{ get => body;}

    void Start()
    { 

        EventHandler.Instance.InvokeOnNextScene();

        SetCameraOrthographicSize();
    }

    public void OnEnable() {
        EventHandler.Instance.OnNextScene += Next;
        EventHandler.Instance.OnBack += Back;

        EventHandler.Instance.OnRateApp += RateApp;
        EventHandler.Instance.OnRestoreApp += RestoreApp;
        EventHandler.Instance.OnMoreApps += MoreApps;
        EventHandler.Instance.OnShareApp += ShareApp;

        EventHandler.Instance.OnLoadLevelAction += LoadLevel;
    }

    private void ShareApp()
    {
        Debug.Log("Share Button Clicked");
        DateTime dt = DateTime.Now;
        StartCoroutine("TakeScreenShot");
    }
    IEnumerator TakeScreenShot()
    {
        yield return new WaitForEndOfFrame();
        Texture2D tx = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tx.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        tx.Apply();

        string path = Path.Combine(Application.temporaryCachePath, "shareImage.png");
        File.WriteAllBytes(path, tx.EncodeToPNG());
        Destroy(tx);

        new NativeShare()
            .AddFile(path)
            .SetSubject("Found Interesting Game")
            #if UNITY_ANDROID
                .SetText(
                                "Hello, I have found a intersting game on PlayStore.\n" +
                                "Below is the link to download it.\n"+
                                "https://apps.apple.com/in/app/-/id" + androidRateAppURL +
                                "\n Download more games form same developer.\n"+
                                "https://apps.apple.com/au/developer/sonam-jain/id" + playStoreURL
                            ).
            #elif UNITY_IPHONE
                            .SetText(
                                "Hello, I have found a intersting game on AppStore.\n" +
                                "Below is the link to download it.\n"+
                                "https://apps.apple.com/in/app/-/id" + iOSRateAppURL +
                                "\n Download more games form same developer.\n"+
                                "https://apps.apple.com/au/developer/sonam-jain/id" + iOSAppStoreURL
                            )
             #endif
            .Share();

    }

    private void MoreApps()
    {
        Debug.Log("More Button Clicked");
#if UNITY_IPHONE
            Application.OpenURL("https://apps.apple.com/au/developer/sonam-jain/id" + iOSAppStoreURL);
#endif

    }

    private void RestoreApp()
    {
        Debug.Log("Restore Button Clicked");
    }

    private void RateApp()
    {
        Debug.Log("Rate Button Clicked");
#if UNITY_IPHONE
            Application.OpenURL("https://apps.apple.com/in/app/-/id" + iOSRateAppURL);
#endif
    }

    public void OnDisable() {
        EventHandler.Instance.OnNextScene -= Next;
        EventHandler.Instance.OnBack -= Back;

        EventHandler.Instance.OnRateApp -= RateApp;
        EventHandler.Instance.OnRestoreApp -= RestoreApp;
        EventHandler.Instance.OnMoreApps -= MoreApps;
        EventHandler.Instance.OnShareApp -= ShareApp;

        EventHandler.Instance.OnLoadLevelAction -= LoadLevel;
    }


    public void Next()
   {
       if(i < ScreenAreas.Length)
       {
           ScreenAreas[i].SetActive(true);
           UIPanels[i].SetActive(true);
       }
       if(i!=0)
       {
           ScreenAreas[i-1].SetActive(false);
           UIPanels[i-1].SetActive(false);
       }
       i++;
       print (i+" in next");
   }

   public void Back()
   {
        i--;
        print(i+ " in back");
        ScreenAreas[i].SetActive(false);
        UIPanels[i].SetActive(false);  

        if(i!=0)
        {
            ScreenAreas[i-1].SetActive(true);
            UIPanels[i-1].SetActive(true);
        }     
   }

    public void Home()
    {
        print(i + " in Home");
        ScreenAreas[i-1].SetActive(false);
        UIPanels[i-1].SetActive(false);
        i = 0;
        ScreenAreas[i].SetActive(true);
        UIPanels[i].SetActive(true);
    }

    private void LoadLevel(int levelId)
    {
        for(int i=1;i<=body.Length;i++)
        {
            body[i - 1].SetActive(false);
            print("False LevelId is " + levelId);
            if (levelId == i)
            {
                body[i-1].SetActive(true);
                //levelBgImage[i - 1].sprite = LevelSetUpSO.LevelBg;
                print("LevelId is " + levelId);
            }
        }
    }

    private void SetCameraOrthographicSize()
    {
        // Setting camera orthographic size accroding to the background image of
        //Game.If you want to calculate width and height use the below commented
        //code and comment below line

        Camera.main.orthographicSize = backgroundImage.bounds.size.y / 2;
        // this code will calculate camera orthograhpic size using width and height ratio
        // uncomment this block of code

  
    }

}



