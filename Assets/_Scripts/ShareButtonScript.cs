using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareButtonScript : MonoBehaviour
{
    [SerializeField]
    Button btnSharePrefab;
    void Start()
    {
        btnSharePrefab.onClick.AddListener(ShareButtonClick);
    }

    public void ShareButtonClick()
    {
        EventHandler.Instance.InvokeOnButtonClickSound();
        EventHandler.Instance.InvokeOnShareApp();
    }
}
