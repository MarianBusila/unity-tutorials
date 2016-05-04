using UnityEngine;
using System.Collections;

public class ExplosionForce : MonoBehaviour
{

    public float force = 100f;
    public float radius = 5f;
    public float upwardsModifier = 0f;
    public ForceMode forceMode;
    

	void FixedUpdate ()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, radius))
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
                rigidbody.AddExplosionForce(force, transform.position, radius, upwardsModifier, forceMode);
        }
	}
}
