using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene2 : Scene
{
    
    protected override void OnClose(Callback<bool> callback)
    {

    }

    protected override void OnHide(Callback<bool> callback)
    {
       
    }

    protected override void OnOpen(Callback<bool> callback)
    {
       
        AssetBundle ad = assetBundleManager.GetAssetBundle("cube03.myab");
        GameObject ob = MonoBehaviour.Instantiate(ad.LoadAsset("cube03")) as GameObject;
        ob.transform.SetParent(this.transform);
        ob.transform.localPosition = new Vector3(0, 2, 5);
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
