using UnityEngine;

public class GunScript : MonoBehaviour {

	// Use this for initialization
	public float range = 100f;
	public Camera cam;
	// Update is called once per frame
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
			Debug.Log (hit.transform.name);
            TargetSelectionScript.getInstance().checkTarget(hit.transform.gameObject);
			Target target = hit.transform.GetComponent<Target>();
			if (target != null) {

			}
		}
	}
				
			
	


}
			
			