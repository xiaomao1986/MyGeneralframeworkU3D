using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class My_ExportAssetBundles : MonoBehaviour
{
    private static void BuilbABS(string BundleName,params string[] resourcesAssets)
    {
        AssetBundleBuild bundle = new AssetBundleBuild();
        bundle.assetBundleName = BundleName;
        bundle.assetNames = resourcesAssets;
    
    }

    private static string path1 = "";
    public static void CreateBundles()
    {
        GUI.Label(new Rect(250, 40, 60, 20), "选择路径：");
        GUI.TextArea(new Rect(310, 40, 500, 20), path1);
        if (GUI.Button(new Rect(810, 40, 100, 20), "选择"))
        {
            path1 = EditorUtility.OpenFolderPanel("", "", "");
            DirectoryInfo dir = new DirectoryInfo(path1);
            ListFiles(path1);
            foreach (DirectoryInfo NextFolder in dir.GetDirectories("*"))
            {
                ListFiles(NextFolder.FullName);
            }
        }
    }
    public static void ListFiles(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        foreach (FileInfo item in dir.GetFiles("*.prefab"))
        {
            Debug.Log("==1==" + item.FullName);
        }
    }


    //[MenuItem("Assets/Build AssetBundle Scene")]
    static void MyBuild()
    {
        // 需要打包的场景名字
        string[] levels = { "Assets/2.unity" };
        // 注意这里【区别】通常我们打包，第2个参数都是指定文件夹目录，在此方法中，此参数表示具体【打包后文件的名字】
        // 记得指定目标平台，不同平台的打包文件是不可以通用的。最后的BuildOptions要选择流格式
        BuildPipeline.BuildPlayer(levels, Application.dataPath + "/Scene.unity3d", BuildTarget.Android, BuildOptions.BuildAdditionalStreamedScenes);
        // 刷新，可以直接在Unity工程中看见打包后的文件
        AssetDatabase.Refresh();

    }



    public static string sourcePath = Application.dataPath + "/Resources";
    const string AssetBundlesOutputPath = "/StreamingAssets";

    [MenuItem("Custom/BuildAssetBundle")]
    public static void BuildAssetBundle()
    {
        ClearAssetBundlesName();
        Pack(sourcePath);
        string outputPath = Path.Combine(AssetBundlesOutputPath, Platform.GetPlatformFolder(EditorUserBuildSettings.activeBuildTarget));
        string sd = outputPath + ".myab";
        if (!Directory.Exists(sd))
        {
            Directory.CreateDirectory(sd);
        }
        Debug.Log("--outputPath---" + outputPath);
        BuildPipeline.BuildAssetBundles(sd, 0, EditorUserBuildSettings.activeBuildTarget);
        AssetDatabase.Refresh();
    } 
    static void ClearAssetBundlesName()
    {
        int length = AssetDatabase.GetAllAssetBundleNames().Length;
        Debug.Log(length);
        string[] oldAssetBundleNames = new string[length];
        for (int i = 0; i < length; i++)
        {
            oldAssetBundleNames[i] = AssetDatabase.GetAllAssetBundleNames()[i];
        }

        for (int j = 0; j < oldAssetBundleNames.Length; j++)
        {
            AssetDatabase.RemoveAssetBundleName(oldAssetBundleNames[j], true);
        }
        length = AssetDatabase.GetAllAssetBundleNames().Length;
        Debug.Log(length);
    }
    static void Pack(string source)
    {
        //Debug.Log("Pack source " + source);  
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
                if (!files[i].Name.EndsWith(".meta"))
                {
                    fileWithDepends(files[i].FullName);
                }
            }
        }
    }
    static void fileWithDepends(string source)
    {
        string _source = Replace(source);
        string _assetPath = "Assets" + _source.Substring(Application.dataPath.Length);
        string[] dps = AssetDatabase.GetDependencies(_assetPath);
        foreach (var dp in dps)
        {
            if (dp.EndsWith(".cs"))
                continue;
            AssetImporter assetImporter = AssetImporter.GetAtPath(dp);
            string pathTmp = dp.Substring("Assets".Length + 1);
            string assetName = pathTmp.Substring(pathTmp.IndexOf("/") + 1);
            assetName = assetName.Replace(Path.GetExtension(assetName), ".myab");
            Debug.Log(assetName);
            assetImporter.assetBundleName = assetName;
        }
    }
    //设置要打包的文件  
    static void file(string source)
    {
        string _source = Replace(source);
        string _assetPath = "Assets" + _source.Substring(Application.dataPath.Length);
        string _assetPath2 = _source.Substring(Application.dataPath.Length + 1);
        AssetImporter assetImporter = AssetImporter.GetAtPath(_assetPath);
        string[] dps = AssetDatabase.GetDependencies(_assetPath);
        foreach (var dp in dps)
        {
            Debug.Log("dp " + dp);
        }
        string assetName = _assetPath2.Substring(_assetPath2.IndexOf("/") + 1);
        assetName = assetName.Replace(Path.GetExtension(assetName), ".unity3d");
        Debug.Log(assetName);
        assetImporter.assetBundleName = assetName;
    }

    static string Replace(string s)
    {
        return s.Replace("\\", "/");
    }
}