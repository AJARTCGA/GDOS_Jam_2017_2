using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelectionScript : MonoBehaviour {

    GameObject curTarget;
    GameObject dummyTarget;
    public Camera mainCamera;
    public Camera targetCamera;
    static TargetSelectionScript instance;

	void Start ()
    {
        instance = this;
        selectNewTarget();
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            selectNewTarget();
        }
	}

    void selectNewTarget()
    {
        if(curTarget != null)
        {
            curTarget.name = "NotTarget";
        }
        if(dummyTarget != null)
        {
            Destroy(dummyTarget);
        }
        GameObject[] allNPCs = GameObject.FindGameObjectsWithTag("NPC");
        curTarget = allNPCs[Random.Range(0, allNPCs.Length)];
        curTarget.name = "Target";
        dummyTarget = Instantiate(curTarget, targetCamera.transform) as GameObject;
        dummyTarget.transform.localPosition = targetCamera.transform.forward;
        dummyTarget.transform.localPosition -= targetCamera.transform.up;
        dummyTarget.transform.rotation = Quaternion.Euler(0, 150, 0);
        dummyTarget.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        dummyTarget.GetComponent<GoToScript>().enabled = false;
        dummyTarget.GetComponent<Rigidbody>().useGravity = false;
        dummyTarget.name = "DummyTarget";
    }

    public static TargetSelectionScript getInstance()
    {
        if(instance == null)
        {
            instance = new TargetSelectionScript();
        }
        return instance;
    }

    public void checkTarget(GameObject go)
    {
        if(go == curTarget)
        {
            selectNewTarget();
            mainCamera.GetComponent<OneHunnScript>().Play();
			Score.getInstance().add(100);
        }
        else
        {
            if(go.tag == "NPC")
            {
				Score.getInstance().add(-100);
            }
        }

		Debug.Log(Score.getInstance().getScore());
    }

}
