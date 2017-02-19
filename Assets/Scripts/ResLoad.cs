using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResLoad:MonoBehaviour
{

    public static ResLoad Instance;

    public Text t;
    WWW loadwww12 = null;
    public void Start()
    {
        Instance = this;

         AssetBundle cubeBundle = GetAssetBundle("cube.myab");
         GameObject  cube = Instantiate(cubeBundle.LoadAsset("cube")) as GameObject;
         cube.transform.position = new Vector3(0, 0, 5);

        t.text = "wan cheng";
    }

    public WWW getww(string path)
    {
        return loadwww12;
    }
   void Update()
    {


    }
    private AssetBundleManifest manifest;
    public AssetBundle GetAssetBundle(string pathData)
    {
        string path1 = Application.dataPath + "!assets/Android.myab";
        AssetBundle manifestBundle = AssetBundle.LoadFromFile(path1);
        manifest = (AssetBundleManifest)manifestBundle.LoadAsset("AssetBundleManifest");
        manifestBundle.Unload(false);
        AssetBundle cubeBundle = null;
        string[] cubedepends = manifest.GetAllDependencies(pathData);
        Debug.Log(cubedepends.Length);
        AssetBundle[] dependsAssetbundle = new AssetBundle[cubedepends.Length];
        for (int index = 0; index < cubedepends.Length; index++)
        {
            string path = Application.dataPath + "!assets/"+ cubedepends[index];
            dependsAssetbundle[index] = AssetBundle.LoadFromFile(path);
        }
        string path2 = Application.dataPath + "!assets/"+ pathData;
        cubeBundle = AssetBundle.LoadFromFile(path2);
        return cubeBundle;
    }


}
   
