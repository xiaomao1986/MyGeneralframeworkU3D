using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleManager
{
    private LoadAssetBundle loadAssetBundle = null;
  
    private Dictionary<string, AssetBundle> m_BundleDic;

    private Dictionary<string, AssetBundle> DependenceBundleDic;

    public AssetBundleManager()
    {
        m_BundleDic = new Dictionary<string, AssetBundle>();
        DependenceBundleDic = new Dictionary<string, AssetBundle>();
        loadAssetBundle = new LoadAssetBundle(this);
    }
    public AssetBundle GetAssetBundle(string ABname)
    {
        if (m_BundleDic.ContainsKey(ABname))
        {
            return m_BundleDic[ABname];
        }
        else
        {
                AssetBundle tmpABundle=null;
                tmpABundle = loadAssetBundle.GetBundle(ABname);
                m_BundleDic.Add(ABname, tmpABundle);
                return tmpABundle;
        }
    }

    public void ADDBundleDependenceDic(string _name,AssetBundle ab)
    {
        if (!DependenceBundleDic.ContainsKey(_name))
        {
            DependenceBundleDic.Add(_name,ab);
        }

    }

    public bool FindmBundleDependenceDic(string _name)
    {
        if (DependenceBundleDic.ContainsKey(_name))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
