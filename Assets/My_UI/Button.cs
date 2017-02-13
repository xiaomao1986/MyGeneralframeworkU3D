using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using XLua;

namespace my_UI
{
    [XLua.LuaCallCSharp]
    class Button : IUIinterface
    {
        [CSharpCallLua]
        public delegate void bittonClick();
        public GameObject buttonObj = null;
        public void initLua(string luaName)
        {
            LuaMag.luaEnv.DoString(luaName);
        }
        public Button()
        {
            buttonObj = MonoBehaviour.Instantiate(Resources.Load("Button")) as GameObject;
        }

    }
}
