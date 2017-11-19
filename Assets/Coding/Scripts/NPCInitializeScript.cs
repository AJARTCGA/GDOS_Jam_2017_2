using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInitializeScript : MonoBehaviour
{
    static Color[] possibleColors = new Color[10];
    
    GameObject meshObj;
    GameObject headRef;

    void Start()
    {
        GameObject tmp;
        tmp = transform.Find("Base").gameObject;
        meshObj = tmp.transform.Find("MeshObj").gameObject;
        tmp = tmp.transform.Find("Character2_Reference").gameObject;
        tmp = tmp.transform.Find("Character2_Hips").gameObject;
        tmp = tmp.transform.Find("Character2_Spine").gameObject;
        tmp = tmp.transform.Find("Character2_Spine1").gameObject;
        tmp = tmp.transform.Find("Character2_Spine2").gameObject;
        tmp = tmp.transform.Find("Character2_Neck").gameObject;
        headRef = tmp.transform.Find("Character2_Head").gameObject;
        if (headRef.transform.childCount == 0)
        {
            NPCCostumeSingleton.CostumeStruct costume = NPCCostumeSingleton.getInstance().getCostume();
            meshObj.GetComponent<SkinnedMeshRenderer>().material.color = costume.color;

            GameObject placed = Instantiate(costume.hat, headRef.transform) as GameObject;
            placed.transform.parent = headRef.transform;
            if (costume.faceItem != null)
            {
                placed = Instantiate(costume.faceItem, headRef.transform) as GameObject;
            }
            placed.transform.parent = headRef.transform;
        }

    }
	
	void Update ()
    {
		
	}
}
