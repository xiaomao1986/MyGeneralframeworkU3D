using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppConfig
{
    public static string AppHttp = "http://127.0.0.1";
    public static string AppUpdataPath = "/StreamingAssets/";
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
    public static string AppUpdataConfig = "/StreamingAssets/Android/UpdataConfig.txt";
#elif UNITY_ANDROID
           public static string AppUpdataConfig = "/StreamingAssets/Android/UpdataConfig.txt";
#elif UNITY_IPHONE
           public static string AppUpdataConfig = "/StreamingAssets/IOS/UpdataConfig.txt";
#endif
}
