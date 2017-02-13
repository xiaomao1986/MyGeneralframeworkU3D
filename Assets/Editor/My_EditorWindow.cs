using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class My_EditorWindow : EditorWindow
{
    [MenuItem("GameObject/项目编辑器")]
    static void AddWindow()
    {
        //创建窗口
        Rect wr = new Rect(0, 0, 1024, 768);
        My_EditorWindow window = (My_EditorWindow)EditorWindow.GetWindowWithRect(typeof(My_EditorWindow), wr, true, "项目编辑器");
        window.Show();

    }
    public Rect windowRect = new Rect(20, 20, 120, 50);
    private string function;
    private GameObject SelectionObj=null;
    private string path1 = "1111111111111";
    void OnGUI()
    {
        // GUILayout.Label("功能", EditorStyles.boldLabel);
        if (GUILayout.Button("创建项目", GUILayout.Width(200)))
        {
            function = "创建项目";
        }
        if (GUILayout.Button("预设生成编辑器", GUILayout.Width(200)))
        {
            GameObject[] pAllObjects = (GameObject[])Resources.FindObjectsOfTypeAll<GameObject>();
            foreach (GameObject pObject in pAllObjects)
            {
                Debug.Log(pObject.layer);
                pObject.SetActive(true);
            }
            function = "预设生成编辑器";
        }
        switch (function)
        {
            #region
            case "预设生成编辑器":
                {
                    string objName="";
 
                    bool isSelection = false;
                    GUI.Label(new Rect(250, 0, 500, 20), "预设生成工具");
                    if(Selection.transforms.Length==0)
                    {
                        objName = "选择一个物体";
                        isSelection = false;
                    }
                    else if(Selection.transforms.Length > 1)
                    {
                        objName = "只能选择一个物体";
                        isSelection = false;
                    }
                    else if (Selection.transforms.Length==1)
                    {
                        objName = Selection.transforms[0].name;
                        isSelection = true;
                    }
                    GUI.Label(new Rect(250, 20, 500, 20), objName);
                    if (isSelection)
                    {
                        GUI.Label(new Rect(250, 40, 60, 20), "保存位置：");
                        GUI.TextArea(new Rect(310, 40, 500, 20), path1);  
                        if (GUI.Button(new Rect(810,40,100,20),"选择"))
                        {
                             path1 = EditorUtility.OpenFolderPanel("123","456","789");
                             Debug.Log("----" + path1);
                        }
                    }
                }
                break;
            #endregion
            case "创建项目":
                My_Createproject.Createproject();
                break;
        }
        //GUILayout.Box("234", GUILayout.Width(200), GUILayout.Height(200));
        GUI.Box(new Rect(0, 0, 250, 768), "");
        //GUI.Box(new Rect(251, 0, 500, 768), "");



    }
    void Update()
    {

    }

    void OnFocus()
    {
        Debug.Log("当窗口获得焦点时调用一次");
    }

    void OnLostFocus()
    {
        Debug.Log("当窗口丢失焦点时调用一次");
    }

    void OnHierarchyChange()
    {
        Debug.Log("当Hierarchy视图中的任何对象发生改变时调用一次");
    }

    void OnProjectChange()
    {
        Debug.Log("当Project视图中的资源发生改变时调用一次");
    }

    void OnInspectorUpdate()
    {
        //Debug.Log("窗口面板的更新");
        //这里开启窗口的重绘，不然窗口信息不会刷新
        this.Repaint();
    }

    void OnSelectionChange()
    {
        //当窗口出去开启状态，并且在Hierarchy视图中选择某游戏对象时调用
        foreach (Transform t in Selection.transforms)
        {
            //有可能是多选，这里开启一个循环打印选中游戏对象的名称
            Debug.Log("OnSelectionChange" + t.name);
        }
    }

    void OnDestroy()
    {
        Debug.Log("当窗口关闭时调用");
    }
}