using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class test
{

    public string s="sdf";
    public GameObject obj;
    public test()
    {
        Debug.Log("gouzao");
    }


    public string ss()
    {
        return "ssssss";
    }
    public GameObject getobj()
    {
        obj = new GameObject();
        return obj;
    }
}
