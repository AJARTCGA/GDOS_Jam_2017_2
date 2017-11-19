using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementScript : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    UnityEngine.AI.NavMeshAgent agent;
    public Collider[] ragdollColliders;
    public Joint[] ragdollJoints;
    public bool isRagdoll;

    void Start()
    {
        GameObject go = new GameObject();
        Rigidbody rb = go.AddComponent<Rigidbody>();
        
        anim = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        foreach(Collider col in ragdollColliders)
        {
            col.enabled = false;
        }
        foreach (Joint joint in ragdollJoints)
        {
            joint.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
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

    public void OnHit()
    {
        anim.enabled = false;
        agent.enabled = false;
        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }
        foreach (Joint joint in ragdollJoints)
        {
            joint.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        isRagdoll = true;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
