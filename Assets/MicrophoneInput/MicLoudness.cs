using UnityEngine;
using System.Collections;

public class MicLoudness : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float loudness = MicInput.loudness;
        Debug.Log("loudness: " + loudness);
        if(loudness > 10.0f)
        {
            Vector3 previousScale = transform.localScale;
            previousScale.y = loudness / 10f;
            transform.localScale = previousScale;
        }
        else
        {
            transform.localScale = Vector3.one;
        }
    }
}
