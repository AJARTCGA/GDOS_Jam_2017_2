using UnityEngine;

public class GunScript : MonoBehaviour {

	public float range = 100f;
	public Camera cam;
    public int forceToApply = 100; 

	void Update () 
	{

		if (Input.GetButtonDown ("Fire1")) 
		{
			Shoot();
		}
	}

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {
            TargetSelectionScript.getInstance().checkTarget(hit.transform.gameObject);
            GameObject hitObj = hit.transform.gameObject;
            if (hitObj.tag != "NPC")
            {
                Rigidbody rb = hitObj.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    rb.AddForceAtPosition(cam.transform.forward, hit.point);
                }
            }
		}
	}
				
			
	


}
			
			