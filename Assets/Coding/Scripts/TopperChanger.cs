using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopperChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Topper"))
        {
            go.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
