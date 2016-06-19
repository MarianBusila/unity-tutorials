using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    public float distance = 1.0f;
    public LayerMask layerMask = -1;
    public string buttonName = "Fire1";

    private bool displayInteract = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance, layerMask))
        {
            displayInteract = true;
            if(Input.GetButtonDown(buttonName))
            {
                Debug.Log("HitButton");
                hit.collider.SendMessageUpwards("Interact");
            }
            
        }
        else
            displayInteract = false;
	}

    void OnGui()
    {
        if(displayInteract == true)
            GUILayout.Label("Press Fire1 to Interact");
    }
}
