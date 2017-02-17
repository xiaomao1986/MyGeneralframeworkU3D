using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scene : MonoBehaviour
{
    public string sceneName="";
    public AssetBundleManager assetBundleManager=null;
    public void Awake()
    {
        Debug.Log("Scene  Awake");
        AppStart.Instance.tt.text = "Scene  Awake";
        this.transform.position = Vector3.zero;
        assetBundleManager = AppStart.Instance.assetBundleManager;
    }
    public void Open(Callback<bool> callback)
    {
        this.OnOpen(callback);
    }
    protected abstract void OnOpen(Callback<bool> callback);
    /// <summary>
    /// 关闭场景
    /// </summary>
    public void Close(Callback<bool> callback)
    {
        this.OnClose(callback);
    }
    protected abstract void OnClose(Callback<bool> callback);
    /// <summary>
    /// 显示场景
    /// </summary>
    public void Show(Callback<bool> callback)
    {
        this.OnShow(callback);
    }
    protected abstract void OnShow(Callback<bool> callback);

    /// <summary>
    /// 隐藏场景
    /// </summary>
    public void Hide(Callback<bool> callback)
    {
        this.OnHide(callback);
    }
    protected abstract void OnHide(Callback<bool> callback);

}
