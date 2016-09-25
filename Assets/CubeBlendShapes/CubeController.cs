using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

    public float speed = 40f;

    const int Shrink = 0;
    const int RaiseTopEdges = 1;

    SkinnedMeshRenderer skinnedMeshRenderer;
    
    float nextUpdate;
    float interval;
    float newWeight;
    float previousWeight;
    float distance;

    // Use this for initialization
    void Start () {
        float startWeight = 100f;
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.SetBlendShapeWeight(Shrink, startWeight);
        skinnedMeshRenderer.SetBlendShapeWeight(RaiseTopEdges, startWeight);
        previousWeight = startWeight;
        newWeight = Random.Range(0f, 100f);
        distance = Mathf.Abs(previousWeight - newWeight);
        interval = distance / speed;
        nextUpdate = Time.time + interval;
    }
		
	void FixedUpdate ()
    {
        if (Time.time >= nextUpdate)
        {
            previousWeight = newWeight;
            newWeight = Random.Range(0f, 100f);
            distance = Mathf.Abs(previousWeight - newWeight);
            interval = distance / speed;
            nextUpdate = Time.time + interval;

            previousWeight = skinnedMeshRenderer.GetBlendShapeWeight(Shrink);
            //Debug.Log("New weight : " + newWeight);
        }
        else
        {
            float percentage = 1 - (nextUpdate - Time.time) / interval;
            float value = Mathf.Lerp(previousWeight, newWeight,  percentage);
            skinnedMeshRenderer.SetBlendShapeWeight(Shrink, value);
            skinnedMeshRenderer.SetBlendShapeWeight(RaiseTopEdges, value);
            //Debug.Log("Percent : " + percentage);
        }

    }
}
