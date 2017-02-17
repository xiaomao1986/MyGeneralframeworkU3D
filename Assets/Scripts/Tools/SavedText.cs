using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
public class SavedText 
{
    public static void CreateFile(string path, string name, string jd)
    {
        try
        {
            Debug.Log("---jd---" + jd);

            string p = path + name+".txt";
            Debug.Log("---p---" + p );
            StreamWriter sw;
            FileInfo t = new FileInfo(p);
            if (!t.Exists)
            {
                sw = t.CreateText();
            }
            else
            {
                FileStream fs = new FileStream(path + name + ".txt", FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
            }
            sw.Flush();
            sw.Write(jd);
            sw.Close();
            sw.Dispose();
        }
        catch (System.Exception e)
        {

        }
    }
}
