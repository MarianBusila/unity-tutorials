using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public int countX = 3;
    public int countY = 3;
    public int countZ = 3;
    public GameObject objectToSpawn;
    public Vector3 objectSpacing = Vector3.one;


	// Use this for initialization
	void Start ()
    {
	    for(int x = 0; x < countX; x++)
            for (int y = 0; y < countY; y++)
                for (int z = 0; z < countZ; z++)
                {
                    Instantiate(objectToSpawn, transform.position + transform.right * x * objectSpacing.x + transform.up * y * objectSpacing.y + transform.forward * z * objectSpacing.z, Quaternion.identity);
                }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
