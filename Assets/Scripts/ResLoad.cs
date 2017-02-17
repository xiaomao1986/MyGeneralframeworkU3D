using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResLoad 
{

    public static ResLoad Instance;

    public Text t;
    string path1= AssetPath.AssetBundlePath() + "UpdataConfig.txt";
    WWW loadwww12 = null;
    public void Start()
    {
        Instance = this;
        Debug.Log("ResLoadResLoadResLoadResLoadResLoadResLoadResLoad---");
    }

    public WWW getww(string path)
    {
      AppStart.Instance.StartCoroutine(loadwww(path, loadwww12));
        while (true)
        {
            if (loadwww12 != null)
            {
              
                return loadwww12;
            }
        }
    }
    private IEnumerator loadwww(string path, WWW www)
    {
        loadwww12 = new WWW(path);
        yield return loadwww12;
        if (loadwww12.error==null)
        {
            Debug.Log("ggggg-34-");
        }
       
    }
}
   
