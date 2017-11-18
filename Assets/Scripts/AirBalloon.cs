using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBalloon : MonoBehaviour {

	public GameObject go;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Random.Range(0f,0.05f), Random.Range(0f,0.05f), Random.Range(0f,0.05f));
	}
}
