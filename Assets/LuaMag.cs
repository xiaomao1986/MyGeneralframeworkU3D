using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaMag : MonoBehaviour {

    internal static LuaEnv luaEnv = new LuaEnv();
    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;
    void Start ()
    {
		

	}
    void Update()
    {
        if (Time.time - LuaBehaviour.lastGCTime > GCInterval)
        {
            luaEnv.Tick();
            LuaBehaviour.lastGCTime = Time.time;
        }
    }
    void OnDestroy()
    {
        luaEnv.Dispose();
    }
}
