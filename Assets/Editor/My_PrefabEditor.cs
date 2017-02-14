using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using LitJson;
public class My_PrefabEditor
{
    private static GameObject SelectionObj = null;
    private static string path1 = "";
    private static bool isToggle0;
    private static string jsonDatas="";
    public static void CrearePrefab()
    {
        string objName = "";

        isToggle0 = GUI.Toggle(new Rect(250, 70, 120, 20), isToggle0, "批量导出Prefab");
        bool isSelection = false;
        GUI.Label(new Rect(250, 0, 500, 20), "预设生成工具");
        if (Selection.transforms.Length == 0)
        {
            objName = "选择一个物体";
            isSelection = false;
        }
        else if (Selection.transforms.Length > 1)
        {
            objName = "只能选择一个物体";
            isSelection = false;
        }
        else if (Selection.transforms.Length == 1)
        {
            objName = Selection.transforms[0].name;
            isSelection = true;
        }
        GUI.Label(new Rect(250, 20, 500, 20), objName);
        if (isSelection)
        {
            GUI.Label(new Rect(250, 40, 60, 20), "保存位置：");
            GUI.TextArea(new Rect(310, 40, 500, 20), path1);
            if (GUI.Button(new Rect(810, 40, 100, 20), "选择"))
            {
                path1 = EditorUtility.OpenFolderPanel("123", "456", "789");
                Debug.Log("----" + path1);
            }
            JsonData jd = new JsonData();
            jd["UIversionNumber"] = "0.0.0.0.1";
            GUI.TextArea(new Rect(310, 100, 500, 200), jd.ToJson());

        }
    }

}
