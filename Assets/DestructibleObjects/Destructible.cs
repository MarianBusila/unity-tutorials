using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

    public GameObject debrisPrefab;
	void OnMouseDown()
    {
        DestroyMe();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.impactForceSum.magnitude > 1.0f)
            DestroyMe();
    }

    void DestroyMe()
    {
        if (debrisPrefab)
        {
            Instantiate(debrisPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
