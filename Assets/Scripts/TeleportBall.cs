using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBall : MonoBehaviour {

    public int counter;
    Transform t;

	// Use this for initialization
	void Start () {
        counter = 500;
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        counter--;
        if (counter <= 0)
        {
            t.position = new Vector3(Random.Range(-50, 50), -9, Random.Range(-40, 60));
            counter = 500;
        }
	}
}
