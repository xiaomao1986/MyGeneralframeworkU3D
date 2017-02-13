using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class UIManager
{

    [CSharpCallLua]
    public delegate void testGameObject(GameObject p);

    public GameObject UIroot;
    private LuaTable luatable;
    testGameObject testobj;
    public UIManager(string Lua)
    {
        LuaMag.luaEnv.DoString(Lua);
        LuaMag.luaEnv.Global.Set("CSUIManager", this);
        LuaMag.luaEnv.Global.Get("luaInit", out testobj);
        testobj(UIroot);
    }
    public void CreateUIroot()
    {
        UIroot = MonoBehaviour.Instantiate(Resources.Load("Canvas")) as GameObject;
    }
    private Dictionary<string, my_UI.IUIinterface> UIdictionary = new Dictionary<string, my_UI.IUIinterface>();

    

}
