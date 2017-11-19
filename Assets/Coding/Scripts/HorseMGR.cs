using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMGR : MonoBehaviour {
	float horsePos = 0f;
	public bool goingUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (goingUp) {
			horsePos += .05f;
			transform.Translate (0f, 0.05f, 0f);

		} else {
			horsePos -= .05f;
			transform.Translate (0f, -0.05f, 0f);
		}
			

		if ((horsePos > 1.5f && goingUp) || (horsePos < -.2f && !goingUp ))
			goingUp = !goingUp;
			
	}
}
