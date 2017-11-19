using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelectionScript : MonoBehaviour
{

    GameObject curTarget;
    GameObject dummyTarget;
    public Camera mainCamera;
    public Camera targetCamera;
    static TargetSelectionScript instance;

    TargetSelectionScript()
    {
    }
    void Start()
    {
        instance = this;
        selectNewTarget();
    }

    void Update()
    {
    }

    void selectNewTarget()
    {
        if (curTarget != null)
        {
            curTarget.name = "NotTarget";
        }
        if (dummyTarget != null)
        {
            Destroy(dummyTarget);
        }
        GameObject[] allNPCs = GameObject.FindGameObjectsWithTag("NPC");
        GameObject tmp = allNPCs[Random.Range(0, allNPCs.Length)];
        while (tmp == curTarget || tmp.GetComponent<NPCMovementScript>().isRagdoll)
        {
            tmp = allNPCs[Random.Range(0, allNPCs.Length)];
        }
        curTarget = tmp;
        curTarget.name = "Target";
        dummyTarget = Instantiate(curTarget, targetCamera.transform) as GameObject;
        dummyTarget.transform.localPosition = targetCamera.transform.forward * 1.5f;
        dummyTarget.transform.localPosition -= targetCamera.transform.up * 1.5f;
        dummyTarget.transform.rotation = Quaternion.Euler(0, 150, 0);
        dummyTarget.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        dummyTarget.GetComponent<GoToScript>().enabled = false;
        dummyTarget.GetComponent<Rigidbody>().useGravity = false;
        dummyTarget.name = "DummyTarget";
    }

    public static TargetSelectionScript getInstance()
    {
        if (instance == null)
        {
            instance = new TargetSelectionScript();
        }
        return instance;
    }

    public void checkTarget(GameObject go)
    {
        if (go == curTarget)
        {
            selectNewTarget();
            mainCamera.GetComponent<OneHunnScript>().Play();
            Score.getInstance().add(100);
            go.GetComponent<NPCMovementScript>().OnHit();
        }
        else
        {
            if (go.tag == "NPC")
            {
                NPCMovementScript script = go.GetComponent<NPCMovementScript>();
                if (!script.isRagdoll)
                {
                    Score.getInstance().add(-100);
                    go.GetComponent<NPCMovementScript>().OnHit();
                }
            }
        }

        Debug.Log(Score.getInstance().getScore());
    }

    public static void refresh()
    {
        instance = new TargetSelectionScript();
    }
}
