using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHunnScript : MonoBehaviour {
    public GameObject oneHunnaObj;
    MeshRenderer renderer;
    Transform finalTrans;
    Transform startingTrans;
    bool isPlaying = false;
    float timer = 0;
	void Start ()
    {
        renderer = oneHunnaObj.GetComponent<MeshRenderer>();
        renderer.enabled = false;
        finalTrans = new GameObject().transform;
        startingTrans = new GameObject().transform;
        copyTransformData(oneHunnaObj.transform, finalTrans);
	}
	
	void Update ()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime * 2;
            if (timer < 1.5)
            { 
                oneHunnaObj.transform.localPosition = Vector3.Lerp(startingTrans.localPosition, finalTrans.localPosition, timer);
                oneHunnaObj.transform.localRotation = Quaternion.Lerp(startingTrans.localRotation, finalTrans.localRotation, timer);
                oneHunnaObj.transform.localScale = Vector3.Lerp(startingTrans.localScale, finalTrans.localScale, timer);
            }
            else
            {
                oneHunnaObj.transform.localPosition = finalTrans.localPosition;
                oneHunnaObj.transform.localRotation = finalTrans.localRotation;
                oneHunnaObj.transform.localScale = finalTrans.localScale;
            }
            if (timer >= 2)
            {
                
                isPlaying = false;
                renderer.enabled = false;
                timer = 0;
            }
        }
	}

    public void Play()
    {
        oneHunnaObj.transform.localPosition = new Vector3(Random.Range(-25.0f, 25.0f), Random.Range(-25.0f, 25.0f), Random.Range(-25.0f, 25.0f));
        oneHunnaObj.transform.localRotation = Quaternion.Euler(new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)));
        oneHunnaObj.transform.localScale = new Vector3(Random.Range(0.1f, 5.0f), Random.Range(0.1f, 5.0f), Random.Range(0.1f, 5.0f));
        renderer.enabled = true;
        copyTransformData(oneHunnaObj.transform, startingTrans);

        isPlaying = true;
        timer = 0;
    }

    void copyTransformData(Transform src, Transform dest)
    {
        dest.localPosition = src.localPosition;
        dest.localRotation = src.localRotation;
        dest.localScale = src.localScale;
    }
}
