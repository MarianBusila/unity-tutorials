using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

    public GameObject objectToSpawn;
    public float delay = 1f;
	// Use this for initialization
	void Start () {
        Invoke("Spawn", delay);
	}

	void Spawn () {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        Invoke("Spawn", delay);
    }
}
