using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

    public Camera newCamera;
    private bool activeNow = false;

	// Use this for initialization
	void Start () {
	
	}
	
	void Interact ()
    {
        activeNow = !activeNow;

        if (activeNow)
        {
            newCamera.enabled = true;
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = false;
        }
        else
        {
            newCamera.enabled = false;
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = true;
        }
	}
}
