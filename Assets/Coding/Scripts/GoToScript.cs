using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToScript : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    public float waitTime;
    float timer = 0;
    Transform curTarget;


	// Use this for initialization
	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        curTarget = NavTargetSingleton.getInstance().getRandomTarget();
        agent.SetDestination(curTarget.position);
        agent.speed = 4;
    }

    // Update is called once per frame
    void Update() {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
                agent.SetDestination(curTarget.position);
                if (Random.Range(0.0f, 1.0f) < 0.5)
                    agent.speed = 4;
                else
                    agent.speed = 8;
            }
        }
        else
        {
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        Transform tmp = NavTargetSingleton.getInstance().getRandomTarget();
                        while (tmp.gameObject == curTarget.gameObject)
                        {
                            tmp = NavTargetSingleton.getInstance().getRandomTarget();
                        }
                        curTarget = tmp;
                        timer = Random.Range(-0.5f, 0.5f) * waitTime + waitTime;

                    }
                }
            }
        }
        /*if (counter <= 0)
        {
            int tmp = (int)Random.Range(0, targets.Count);
            if (tmp != targetNum) {
                targetNum = tmp;
                agent.SetDestination(targets[targetNum].position);
                counter = (int)(Random.Range(wait - 50, wait + 50));
                if (Random.Range(0.0f, 1.0f) < 0.5)
                    agent.speed = 4;
                else
                    agent.speed = 12;
            }
        }*/
	}

}
