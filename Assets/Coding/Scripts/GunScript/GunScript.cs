using UnityEngine;

public class GunScript : MonoBehaviour {

	public float range = 100f;
	public Camera cam;
    public int forceToApply = 100;
    Light pointLight;
    float shootingTimer = 0;
    public float shootingTimerMax = 0.5f;
    GameObject tracePoint;
    Vector3 lastHitPoint;
    public Object particleEffect;

    void Start()
    {
        pointLight = transform.Find("Point light").gameObject.GetComponent<Light>();
        pointLight.enabled = false;
        tracePoint = GameObject.Find("TracePoint");
    }

	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
            if (Time.timeScale > 0)
            {
                Shoot();
            }
		}
        
        if(shootingTimer > 0)
        {
            pointLight.intensity = Random.Range(0.75f, 2.0f);
            pointLight.range = Random.Range(0.02f, 0.10f);
            shootingTimer -= Time.deltaTime;
            Debug.DrawLine(tracePoint.transform.position, lastHitPoint, Color.black);
            if (shootingTimer < 0)
            {
                pointLight.enabled = false;
            }
        }
    }

	void Shoot()
	{
		RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            TargetSelectionScript.getInstance().checkTarget(hit.transform.gameObject);
            GameObject hitObj = hit.transform.gameObject;
            if (hitObj.tag != "NPC")
            {
                Rigidbody rb = hitObj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForceAtPosition(cam.transform.forward * forceToApply, hit.point);
                }
            }
            else
            {
                GameObject go = Instantiate(particleEffect, hit.point, Quaternion.identity) as GameObject;
                go.transform.parent = hitObj.transform;
                
            }
            Target target = hitObj.GetComponent<Target>();
            if (target != null)
            {
                target.OnHit();
            }
            lastHitPoint = hit.point;
        }
        shootingTimer = shootingTimerMax;
        pointLight.enabled = true;
	}
				
			
	


}
			
			