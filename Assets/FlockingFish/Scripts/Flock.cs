﻿using UnityEngine;
using System.Collections;

public class Flock : MonoBehaviour
{
    public float speed = 0.5f;
    float rotationSpeed = 4.0f;
    float minSpeed = 0.8f;
    float maxSpeed = 2.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 3.0f;
    public Vector3 newGoalPos;

    public bool turning = false;

	// Use this for initialization
	void Start ()
    {
        speed = Random.Range(minSpeed, maxSpeed);
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit object");
        if(!turning)
        {
            newGoalPos = this.transform.position - other.gameObject.transform.position;
        }
        turning = true;
    }

    void OnTriggerExit()
    {
        turning = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (turning)
        {
            Vector3 direction = newGoalPos - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            speed = Random.Range(minSpeed, maxSpeed);
        }
        else
        {
            if (Random.Range(0, 10) < 1)
                ApplyRules();
        }

        transform.Translate(0, 0, Time.deltaTime * speed);
	}

    void ApplyRules()
    {
        GameObject[] gos;
        gos = GlobalFlock.allFish;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = GlobalFlock.goalPos;

        float dist;

        int groupSize = 0;
        foreach(GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if(dist <= neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    if(dist < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }
                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed += anotherFlock.speed;
                }
            }
        }

        if(groupSize > 0)
        {
            vcenter = vcenter / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcenter + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }

    }
}
