using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
public class test05 : MonoBehaviour {

    // Use this for initialization
    public static string sourcePath = "/StreamingAssets";
    void Start ()
    {
        Pack(sourcePath);
    }
    static string data = "version|0.0.0.1";
    static void Pack(string source)
    {
        DirectoryInfo folder = new DirectoryInfo(source);
        FileSystemInfo[] files = folder.GetFileSystemInfos();
        int length = files.Length;
        for (int i = 0; i < length; i++)
        {
            if (files[i] is DirectoryInfo)
            {
                Pack(files[i].FullName);
            }
            else
            {
                if (!files[i].Name.EndsWith(".txt"))
                {
                    string s=  files[i].FullName.Replace("\\","/");
                    Debug.Log("files[i].FullName 1" + s);
                    data = data +"\n"+ MD5File(s);
                }
            }
        }
        Debug.Log("data" + data);
        CreateFile(sourcePath, "UpdateConfig", data);
    }
    public static string MD5File(string file)
    {
        try
        {
            FileStream fs = new FileStream(file, FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(fs);
            fs.Close();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            string tSt;
            tSt = file.Replace("E:/StreamingAssets/", "");
            //    string s = file.ToString().Substring(10, file.Length-1);
            Debug.Log("====" + tSt + "----"+ sb.ToString());
            string data = sb.ToString() + "|" + tSt;
            return data;
        }
        catch (Exception ex)
        {
            throw new Exception("md5file() fail, error:" + ex.Message);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    public static void CreateFile(string path, string name, string jd)
    {
        try
        {
            //文件流信息
            StreamWriter sw;
            FileInfo t = new FileInfo(path + "/" + name + ".txt");
            if (!t.Exists)
            {
                //如果此文件不存在则创建
                sw = t.CreateText();
            }
            else
            {
                //如果此文件存在则打开
                FileStream fs = new FileStream(path + "/" + name + ".txt", FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
            }
            sw.Flush();
            //以行的形式写入信息
            sw.Write(jd);
            //关闭流
            sw.Close();
            //销毁流
            sw.Dispose();
            // My_UIEditorToos.Progress();
        }
        catch (System.Exception e)
        {

        }
    }
}
