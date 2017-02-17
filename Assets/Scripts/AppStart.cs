using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppStart : MonoBehaviour
{
    public static AppStart Instance;

    public Text tt;
    public my_SceneManager SceneManager;
    public AssetBundleManager assetBundleManager = null;
    public void Awake()
    {
        assetBundleManager = new AssetBundleManager();
        Instance = this;
        SceneManager = new my_SceneManager();
        SceneManager.OpenScene("TestScene");
    }
    public void Init()
    {
        SceneManager.OpenScene("TestScene");
        SceneManager.OpenScene("TestScene2");
    }
}
