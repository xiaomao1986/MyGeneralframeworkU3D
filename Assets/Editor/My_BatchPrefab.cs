using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class My_BatchPrefab
{

    [MenuItem("Tools/BatchPrefab All Children")]
    public static void BatchPrefab()
    {
        Transform tParent = ((GameObject)Selection.activeObject).transform;
        Debug.Log(tParent.name);
        Object tempPrefab;
        int i = 0;
        foreach (Transform child in tParent)
        {
            Debug.Log("111111"+tParent.name);
            tempPrefab = PrefabUtility.CreateEmptyPrefab("Assets/Prefab" + child.name + ".prefab");
            tempPrefab = PrefabUtility.ReplacePrefab(child.gameObject, tempPrefab);
            i++;
        }

    }
}
