using UnityEngine;
using System.Collections;

public class LaserProjection : MonoBehaviour {

    public GameObject laser;
    private GameObject laserInstance;
    public float offset = 0.1f;
    
	// Update is called once per frame
	void Update () {
        RaycastHit hitPoint;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitPoint))
        {
            if (laserInstance == null)
                laserInstance = Instantiate(laser, hitPoint.point + hitPoint.normal * offset, Quaternion.identity) as GameObject;
            else
                laserInstance.transform.position = hitPoint.point + hitPoint.normal * offset;
        }
	}
}
