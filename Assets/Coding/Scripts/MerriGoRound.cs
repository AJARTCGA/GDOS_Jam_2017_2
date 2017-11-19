using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerriGoRound : MonoBehaviour {

	// Use this for initialization
	public bool goingRight;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!goingRight)
			transform.Rotate (0f, -1f, 0f);
		else
			transform.Rotate (0f, 1f, 0f);
	}
}
