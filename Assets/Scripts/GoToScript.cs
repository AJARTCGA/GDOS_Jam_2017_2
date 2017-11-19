using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToScript : MonoBehaviour {

    public List<Transform> targets;
    UnityEngine.AI.NavMeshAgent agent;
    public int wait;
    int counter;//
    int targetNum;

	// Use this for initialization
	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        counter = (int)(Random.Range(wait - 350, wait + 50));
        targetNum = (int)Random.Range(0, targets.Count);
        agent.SetDestination(targets[targetNum].position);
        agent.speed = 4;
    }

    // Update is called once per frame
    void Update() {
        counter--;
        if (counter <= 0)
        {
            int tmp = (int)Random.Range(0, targets.Count);
            if (tmp != targetNum) {
                targetNum = tmp;
                agent.SetDestination(targets[targetNum].position);
                counter = (int)(Random.Range(wait - 50, wait + 50));
                if (Random.Range(0, 1) < 0.5)
                    agent.speed = 4;
                else
                    agent.speed = 8;
            }
        }
	}
}
