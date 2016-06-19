﻿using UnityEngine;
using System.Collections;

public class SwitchToVehicleOnInteract : MonoBehaviour {

    public Behaviour[] vehicleBehaviours;
    public string escapeKey = "Fire1";
    private bool activeNow = false;
    private GameObject player;
    public Transform exitPoint;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        foreach (Behaviour vb in vehicleBehaviours)
            vb.enabled = false; 
    }

    void Update()
    {
        if(activeNow)
        {
            if(Input.GetButtonDown(escapeKey))
            {
                activeNow = false;
                foreach (Behaviour vb in vehicleBehaviours)
                    vb.enabled = false;

                player.transform.position = exitPoint.position;
                player.transform.rotation = exitPoint.rotation;
                player.SetActive(true);
            }
        }
    }
	
	void Interact ()
    {
        if (activeNow == false)
        {
            activeNow = true;

            foreach (Behaviour vb in vehicleBehaviours)
                vb.enabled = true;

            player.SetActive(false);
            
        }
	}
}
