using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class my_SceneManager
{

    private Dictionary<string, Scene> m_curScenes;

    public my_SceneManager()
    {
        m_curScenes = new Dictionary<string, Scene>();
    }	

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_sceneName"></param>
    public void OpenScene(string  _sceneName)
    {
        if (m_curScenes.ContainsKey(_sceneName))
        {
            Scene tmp = m_curScenes[_sceneName];
            tmp.gameObject.SetActive(true);
            tmp.Show(ShowCallback);
        }else
        {
           // IEnumerator add = AddScene(_sceneName);
            AppStart.Instance.StartCoroutine(AddScene(_sceneName));
        }
    }
    /// <summary>
    /// /关闭场景
    /// </summary>
    /// <param name="_sceneName">场景名字</param>
    /// <param name="_isClose">是否真的销毁   False 隐藏场景  true 销毁场景</param>
    public void CloseScene(string _sceneName,bool _isClose=false)
    {
        if (_isClose)
        {

        }
        else
        {

        }
    }
    private AsyncOperation loadingAsync = null;
    private IEnumerator AddScene(string _sceneName)
    {
        if (!m_curScenes.ContainsKey(_sceneName))
        {
            loadingAsync = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
            yield return loadingAsync;
            GameObject go = GameObject.Find(_sceneName);
            Scene scene = null;
            if (go != null)
            {
                scene = go.GetComponent<Scene>();
                scene.sceneName = _sceneName;
                scene.Open(OpenCallback);
                m_curScenes.Add(_sceneName, scene);
            }
            else
            {

            }
        }
    }

    private void OpenCallback(bool _isOpen)
    {

    }
    private void CloseCallback(bool _isClose)
    {

    }
    private void ShowCallback(bool _isShow)
    {

    }
    private void HideCallback(bool _Hide)
    {

    }
    public void Delete()
    {
        m_curScenes.Clear();
    }
}
