using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        TextAsset textLua = (TextAsset)Resources.Load("UIManager.lua");
        UIManager uimag = new UIManager(textLua.text);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
