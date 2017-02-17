/********************************************************
 * 程序：LoadAssetBundle 加载AssetBundle                *
 * 作者：李明洋                                         *
 * QQ:104228011                                         *
 * 时间：2017/02/16                                     *
 * 描述：                                               *
 * 1，该类负责根据Bundle名字 加载StreamingAssets目录    *
 ********************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LoadAssetBundle
{
    private AssetBundleManifest manifest = null;
    private AssetBundleManager m_assetBundleManager;
    public LoadAssetBundle(AssetBundleManager _assetBundleManager)
    {
        m_assetBundleManager = _assetBundleManager;
    }
    private IEnumerator LoadWWW(string paht)
    {
        Debug.Log("LoadWWW----" + paht);
        WWW www = new WWW(paht);
        yield return www;
    }

    //private WWW GetLoadWWW(string paht)
    //{
    //    Debug.Log("GetLoadWWW----"+ paht);
    //    // AppStart.Instance.tt.text = AppStart.Instance.tt.text + "GetLoadWWW = --" + paht + "---";
    //    WWW loadwww = null;
    //    IEnumerator w = LoadWWW(paht);
    //    //   AppStart.Instance.StartCoroutine(LoadWWW(paht));
    //    while (true)
    //    {
    //        if (!w.MoveNext())
    //        {
    //            Debug.Log("MoveNext----" );
    //            AppStart.Instance.tt.text = AppStart.Instance.tt.text + "MoveNext = -----";
    //            return loadwww;
    //        }
    //        object cur = w.Current;
    //        if (cur != null)
    //        {
    //            Debug.Log("MoveNext---22-");

    //            loadwww = cur as WWW;
    //            AppStart.Instance.tt.text = AppStart.Instance.tt.text + "www返回";
    //            if (loadwww==null)
    //            {
    //                AppStart.Instance.tt.text = AppStart.Instance.tt.text + "www空";
    //            }
    //            return loadwww;
    //        }
    //    }
    //}

    ResLoad resload = new ResLoad();
    public AssetBundle GetBundle(string _ABname)
    {
        WWW wAssetBundle = null;
       // try
        //{
            if (manifest == null)
            {
                string Pant = AssetPath.AssetBundleManifestPath();
                AppStart.Instance.tt.text = AppStart.Instance.tt.text + "Pant --" + Pant + "---";
            // WWW manifestWWW = GetLoadWWW(Pant);
               
                WWW manifestWWW = resload.getww(Pant);
                AppStart.Instance.tt.text = AppStart.Instance.tt.text + "manifestWWW --" + manifestWWW + "---";
                if (manifestWWW==null)
                {
                    AppStart.Instance.tt.text = AppStart.Instance.tt.text + "manifestWWW --null--";
                }
                if (manifestWWW.error == null)
                {
                    AssetBundle manifestBundle = manifestWWW.assetBundle;
                    manifest = (AssetBundleManifest)manifestBundle.LoadAsset("AssetBundleManifest");
                    manifestBundle.Unload(false);
                    AppStart.Instance.tt.text = AppStart.Instance.tt.text + "  manifestBundle.Unload(false); ---";
                    wAssetBundle = SetBundleDependence(_ABname);
                    if (wAssetBundle == null)
                    {
                        Debug.LogError("GetBundle wAssetBundle   null ");
                        return null;
                    }
                    if (wAssetBundle.error != null)
                    {
                        Debug.LogError("GetBundle wAssetBundle.error -- " + wAssetBundle.error.ToString());
                        return null;
                    }
                    return wAssetBundle.assetBundle;
                }else
                {
                    AppStart.Instance.tt.text = AppStart.Instance.tt.text + "manifestWWW --" + manifestWWW.error.ToString() + "---";
                }
            }
            else
            {
                wAssetBundle = SetBundleDependence(_ABname);
                if (wAssetBundle == null)
                {
                    Debug.LogError("GetBundle wAssetBundle   null ");
                    return null;
                }
                if (wAssetBundle.error != null)
                {
                    Debug.LogError("GetBundle wAssetBundle.error -- " + wAssetBundle.error.ToString());
                    return null;
                }
                return wAssetBundle.assetBundle;

            }
            return wAssetBundle.assetBundle;
      //  }
        //catch (Exception e)
       // {
        //    AppStart.Instance.tt.text = AppStart.Instance.tt.text + "eee--" + e.ToString();
        //    return wAssetBundle.assetBundle;
       // }


    }
    private WWW SetBundleDependence(string _ABname)
    {
        string[] depNames = manifest.GetAllDependencies(_ABname);
        AssetBundle[] dependsAssetbundle = new AssetBundle[depNames.Length];
        string Path2 = "";
        for (int index = 0; index < depNames.Length; index++)
        {
            Path2 = AssetPath.AssetBundlePath() + depNames[index];
            //WWW www = GetLoadWWW(Path2);
            WWW www = resload.getww(Path2);
            if (www.error == null)
            {
                if (m_assetBundleManager == null)
                {
                    Debug.Log("ppStart.Instanc");
                }
                if (!m_assetBundleManager.FindmBundleDependenceDic(Path2))
                {
                    dependsAssetbundle[index] = www.assetBundle;
                    m_assetBundleManager.ADDBundleDependenceDic(Path2, dependsAssetbundle[index]);
                }
            }
        }
        Path2 = AssetPath.AssetBundlePath() + _ABname;
       //WWW www1 = GetLoadWWW(Path2);
        WWW www1 = resload.getww(Path2);
        return www1;
    }
}
