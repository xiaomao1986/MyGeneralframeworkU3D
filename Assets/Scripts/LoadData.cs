using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadData
{
    public IEnumerator LoadDatawww(string _config)
    {
        // string path = @"file://E:/StreamingAssets/" + _config;

        string path = AppConfig.AppHttp+AppConfig.AppUpdataPath+ _config;
        WWW www = new WWW(path);
        yield return www;
        if (www.error == null)
        {
            string s1 = Application.streamingAssetsPath + "/" + _config;
            string filename = Path.GetFileName(s1);
            string tSt = s1.Replace(filename, "");
            while (Directory.Exists(tSt) == false)
            {
                Directory.CreateDirectory(tSt);
            }
            Stream outStream = File.Create(Application.streamingAssetsPath + "/" + _config);
            byte[] buffer = www.bytes;
            outStream.Write(buffer, 0, buffer.Length);
            outStream.Close();
            AppUpdata.Instance.LoaSum++;
        }
        else
            Debug.Log("LoadData ------www.error--------" + www.error.ToString()+"---"+ path);

    }
     

}
