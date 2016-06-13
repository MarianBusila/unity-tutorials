using UnityEngine;
using System.Collections;

public class GlobalFlock : MonoBehaviour
{
    public GameObject fishPrefab;
    float tankSize = 5;

    static int numFish = 30;
    public static GameObject[] allFish = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;

    // Use this for initialization
    void Start ()
    {
        RenderSettings.fogColor = Camera.main.backgroundColor;
        RenderSettings.fogDensity = 0.06f;
        RenderSettings.fog = true;

        for(int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
        }
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Random.Range(0, 10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize), Random.Range(-tankSize, tankSize));
        }
	}
}
