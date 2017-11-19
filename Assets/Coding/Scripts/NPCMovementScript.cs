using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementScript : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    UnityEngine.AI.NavMeshAgent agent;

	void Start ()
    {
		anim = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        Vector3 vel = agent.velocity;
        Vector3 horizontalVel = new Vector3(vel.x, 0, vel.z);
        float mag = horizontalVel.magnitude;
        anim.SetFloat("Speed", mag);
        if (mag >= 0.001f)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.forward, horizontalVel);
        }
	}
}
