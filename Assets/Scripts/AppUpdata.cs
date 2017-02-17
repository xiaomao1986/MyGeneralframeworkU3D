/********************************************************
 * 程序：AppUpdata 应用更新                             *
 * 作者：李明洋                                         *
 * QQ:104228011                                         *
 * 时间：2017/02/16                                     *
 * 描述：                                               *
 * 1，该类负责 对应用的 资源进行下载                    *
 * 2，本地版本号 与 服务器版本号 对比                   *
 * 3，下载服务器资源 存在本地  StreamingAssets目录      * 
 * 4，下载完毕后 调用 AppStart类 init fangfa            *   
 ********************************************************/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AppUpdata : MonoBehaviour
{
    public static AppUpdata Instance;
    private Dictionary<string, string> m_localupdataConifDic = new Dictionary<string, string>();
    private Dictionary<string, string> m_wwwupdataConifDic = new Dictionary<string, string>();

    private Dictionary<string, string> m_updataConifDic = new Dictionary<string, string>();

    public int LoaSum = 0;
    void Start()
    {
        Instance = this;
        StartCoroutine(LoadlocalUpdateConif());
    }
    void Update()
    {
        if (m_updataConifDic.Count!=0)
        {
            if (LoaSum==m_updataConifDic.Count)
            {
                m_updataConifDic.Clear();
                Debug.Log("下载完成！！");
                string path = Application.streamingAssetsPath+ "/Android/";
                SavedText.CreateFile(path, "UpdataConfig", UpdataConfig);
                AppStart.Instance.Init();
            }
        }
    }
    private string UpdataConfig = "";
    //加载本地 UpdateConif.txt 
    IEnumerator LoadlocalUpdateConif()
    {
        string path = AssetPath.AssetBundlePath() + "UpdataConfig.txt";
        WWW www = new WWW(path);
        yield return www;
        if (www.error == null)
        {
            string[] Arrys = www.text.Split(new char[2] { '\n', '|' });
            for (int i = 0; i < Arrys.Length - 1; i++)
            {
                string key = Arrys[i];
                i++;
                string value = Arrys[i];
                m_localupdataConifDic.Add(key, value);
            }
            StartCoroutine(LoadwwwUpdateConif());
        }
        else
            Debug.Log(" ------www.error--------" + www.error);
    }
    IEnumerator LoadwwwUpdateConif()
    {
        string path = AppConfig.AppHttp+ AppConfig.AppUpdataConfig;
        Debug.Log(" ------LoadwwwUpdateConif----path----" + path);
        WWW www = new WWW(path);
        yield return www;
        if (www.error == null)
        {
            Debug.Log(" ------LoadwwwUpdateConif--------" + www.text);
            UpdataConfig = www.text;
            string[] Arrys = www.text.Split(new char[2] { '\n', '|' });
            for (int i = 0; i < Arrys.Length - 1; i++)
            {
                string key = Arrys[i];
                i++;
                string value = Arrys[i];
                m_wwwupdataConifDic.Add(key, value);
            }
            UpdataContrast();
        }
        else
            Debug.Log(" ------www.error--------" + www.error);
    }

    private void UpdataContrast()
    {
        if (!m_wwwupdataConifDic.ContainsKey("version") || !m_localupdataConifDic.ContainsKey("version"))
        {
            Debug.LogError("更新 配置文件出错！！！未找到 version");
            return;
        }
        if (m_wwwupdataConifDic["version"] == m_localupdataConifDic["version"])
        {
            Debug.Log(" ------版本号相同-------");
            //版本号相同 不做更新 直接进入程序 调用 开启程序方法
            AppStart.Instance.Init();
            return;
        }
        //查找不同
        foreach (var item in m_wwwupdataConifDic)
        {
            //把不相同的配置放进 更新字典里 
            if (item.Key == "version")
            {
                if (m_localupdataConifDic["version"] != item.Value)
                {
                  //  m_updataConifDic.Add(item.Key, item.Value);
                }
            }
            if (!m_localupdataConifDic.ContainsKey(item.Key))
            {
                m_updataConifDic.Add(item.Key, item.Value);
            }
        }
        foreach (var item in m_updataConifDic)
        {
            LoadData load = new LoadData();
            StartCoroutine(load.LoadDatawww(item.Value));
        }
    }
    void DeleteFile(string path)
    {
      //  string _path = @"file://E:/StreamingAssets/Android/Android.manifest";
        string path1 = @"E:\StreamingAssets\Android\UpdateConfig.txt";
        Debug.Log("path--" + path1);
        File.Delete(path1);
    }
}
