using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPath
{
    public enum Platform
    {
        Android = 0,
        IOS = 1,
        Windows = 2
    }
    private static AssetPath.Platform m_platform;

    public static string Path()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        return "file://" + Application.dataPath + "/StreamingAssets/";
#elif UNITY_ANDROID
                return "jar:file://" + Application.dataPath + "!/assets/";
#elif UNITY_IPHONE
                return Application.dataPath + "/Raw/";
#else
            return "";
#endif
    }
    public static string AssetBundlePath()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        m_platform = AssetPath.Platform.Windows;
#elif UNITY_ANDROID
        m_platform = AssetPath.Platform.Android;
#elif UNITY_IPHONE
        m_platform = AssetPath.Platform.IOS;
#endif
        if (Platform.Android == m_platform)
        {
            return Application.streamingAssetsPath + "/Android/";
        }
        if (Platform.IOS == m_platform)
        {
            return Application.streamingAssetsPath + "/IOS/";
        }
        if (Platform.Windows == m_platform)
        {
            return "file://" + Application.streamingAssetsPath + "/Android/";
        }
        return "";
    }

    public static string AssetBundleManifestPath()
    {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        m_platform = AssetPath.Platform.Windows;
#elif UNITY_ANDROID
        m_platform = AssetPath.Platform.Android;
#elif UNITY_IPHONE
        m_platform = AssetPath.Platform.IOS;
#endif
        if (Platform.Android == m_platform)
        {
            return Application.streamingAssetsPath + "/Android/" + "Android.myab";
        }
        if (Platform.IOS == m_platform)
        {
            return Application.streamingAssetsPath + "/IOS/" + "IOS";
        }
        if (Platform.Windows == m_platform)
        {
            return "file://" + Application.streamingAssetsPath + "/Android/" + "Android.myab";
        }
        return "";
    }

    public static string UpdataPath()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        m_platform = AssetPath.Platform.Windows;
#elif UNITY_ANDROID
        m_platform = AssetPath.Platform.Android;
#elif UNITY_IPHONE
        m_platform = AssetPath.Platform.IOS;
#endif
        if (Platform.Android == m_platform)
        {
            return Application.streamingAssetsPath + "/";
        }
        if (Platform.IOS == m_platform)
        {
            return Application.streamingAssetsPath + "/";
        }
        if (Platform.Windows == m_platform)
        {
            return "file://" + Application.streamingAssetsPath + "/";
        }
        return "";
    }
}
