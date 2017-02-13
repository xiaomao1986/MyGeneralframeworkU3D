using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;



[CSharpCallLua]
public delegate void testint(int p);

[CSharpCallLua]
public delegate void testGameObject(GameObject p);

[CSharpCallLua]
public delegate void bittonClick();
[CSharpCallLua]
public delegate void test01(test p);

[LuaCallCSharp]
public class mylua : MonoBehaviour
{
    
    public static mylua Instanic;
    public GameObject UIroot;
    public test tes;
    public LuaEnv luaenv;
    public LuaTable luatable;
    public int tt =10;

    testint testint;
    testGameObject testobj;
    test01 t01;
    Action ac;
    bittonClick onbuttonClick;
    // Use this for initialization
    void Start()
    {
        tes = new test();
        Instanic = this;
        luaenv = new XLua.LuaEnv();
        //luatable = luaenv.NewTable();
        //LuaTable meta = luaenv.NewTable();
        //meta.Set("__index", luaenv.Global);
        //luatable.SetMetaTable(meta);
        //meta.Dispose();
        //luatable.Set("CSmylua", this);
        TextAsset textLua = (TextAsset)Resources.Load("Lua1.lua");
        luaenv.DoString(textLua.text);
        luaenv.Global.Set("mylua",this);

        luaenv.Global.Get("luaInit", out testobj);

        testobj(UIroot);
        luaenv.Global.Get("ButtonClick", out onbuttonClick);
         ac = luaenv.Global.Get<Action>("CreateButton");
       
       
        getText();
    }
    public void getText()
    {
        ac();
        //luaenv.Dispose();
    }

    public GameObject Create()
    {
        GameObject obj = Instantiate(Resources.Load("Button")) as GameObject;
       // obj.GetComponent<Button>().onClick.AddListener(delegate() { onbuttonClick(); });
        return obj;
    }

	// Update is called once per frame
	void Update ()
    {
     
    }
}
