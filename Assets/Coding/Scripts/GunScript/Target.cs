using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int pointToAdd = 0;
    bool hasBeenHit = false;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnHit()
    {
        if (!hasBeenHit)
        {
            Score.getInstance().add(pointToAdd);
            hasBeenHit = true;
        }
		if (audio != null)
			audio.PlayOneShot (audio.clip);
    }
}
