using UnityEngine;
using System.Collections;

public class Caustics : MonoBehaviour {

#if UNITY_ANDROID
    void Start()
    {
    }
#else
    private Projector projector;
    public MovieTexture mt;
	// Use this for initialization
	void Start () {
        projector = GetComponent<Projector>();
        projector.material.SetTexture("_ShadowTex", mt);
        mt.loop = true;
        mt.Play();
	}
#endif
    }
