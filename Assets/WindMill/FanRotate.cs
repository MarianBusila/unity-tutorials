using UnityEngine;
using System.Collections;

public class FanRotate : MonoBehaviour {

    public float RotationSpeed;
    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0f, RotationSpeed, 0f));
    }
}
