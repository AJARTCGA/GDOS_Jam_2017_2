using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour {
	public Light light;

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if ( Random.value > 0.99) //a random chance
		{
			if ( light.enabled == true ) //if the light is on...
			{
				light.enabled = false; //turn it off
			}
			else
			{
				light.enabled = true; //turn it on
			}
		}
}
}
