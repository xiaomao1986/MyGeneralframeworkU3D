using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : Scene
{
    
    protected override void OnClose(Callback<bool> callback)
    {

    }

    protected override void OnHide(Callback<bool> callback)
    {
       
    }

    protected override void OnOpen(Callback<bool> callback)
    {
        AppStart.Instance.tt.text = AppStart.Instance.tt.text+ "OnOpen--";
        GameObject[] obj = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {

                AssetBundle ad = assetBundleManager.GetAssetBundle("obj/cube02.myab");
                obj[i] = MonoBehaviour.Instantiate(ad.LoadAsset("cube02")) as GameObject;
                obj[i].transform.SetParent(this.transform);
                obj[i].transform.localPosition = new Vector3(0, i, 5);
        }
        //AssetBundle ad = assetBundleManager.GetAssetBundle("obj/cube02.myab");
        //GameObject ob = MonoBehaviour.Instantiate(ad.LoadAsset("cube02")) as GameObject;
        //ob.transform.SetParent(this.transform);
        //ob.transform.localPosition = new Vector3(0, 0, 5);
    }

    protected override void OnShow(Callback<bool> callback)
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
