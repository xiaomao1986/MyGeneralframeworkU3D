using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAsset
{

    private string m_sPath = string.Empty;//资源路径
    private WWW m_www = null;

    private int m_iCountRetry = 5;//重复下载次数

    public LoadAsset(string path)
    {
        m_sPath = path;
    }
    public WWW StarLoad()
    {
      WWW result = null;

        while (result == null)
        {
            foreach (WWW obj in LoadWWW())
            {
                result = obj;
            }
            if (m_iCountRetry > 0)
            {
                if (result != null)
                {
                    break;
                }
                m_iCountRetry--;
            }
            else
            {
                break;
            }
        }
        DeInit();
        return result;
    }
    public IEnumerable<WWW> LoadWWW()
    {
        m_www = new WWW(m_sPath);
        yield return m_www;
    }
    private void DeInit()
    {
        if (m_www != null)
        {
            m_www.Dispose();
        }
        m_www = null;
    }




}
