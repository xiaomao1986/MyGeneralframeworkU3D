using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_Createproject
{
    private static string m_project = "";
    private static bool isToggle0;
    private static bool isToggle1;
    public static void Createproject()
    {
        GUI.Label(new Rect(250, 10, 60, 20), "项目名字：");
        isToggle0= GUI.Toggle(new Rect(250, 50, 120, 20), isToggle0, "是否创建Ugui");
        isToggle1 = GUI.Toggle(new Rect(250, 70, 120, 20), isToggle1, "是否创建使用Xlua");
        m_project = GUI.TextField(new Rect(310, 10, 500, 20), m_project);
        if (GUI.Button(new Rect(810, 10, 100, 20), "生成项目"))
        {
            Debug.Log(m_project);
        }
    }
}
