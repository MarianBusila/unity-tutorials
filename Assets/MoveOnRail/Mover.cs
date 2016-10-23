using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public Rail rail;
    public PlayMode playMode;

    private int currentSeg = 0;
    private float transition;
    private bool isCompleted;

    private void Update()
    {
        if (!rail)
            return;
                
        if (!isCompleted)
        {
            Debug.Log("Segment: " + currentSeg);
            Play();
        }
    }

    private void Play()
    {
        transition += Time.deltaTime * 1 / 2.5f;
        if(transition > 1)
        {
            transition = 0;
            currentSeg++;
        }

        if (currentSeg + 1 == rail.Length)
            isCompleted = true;
        else
        {
            transform.position = rail.PositionOnRail(currentSeg, transition, playMode);
            transform.rotation = rail.Orientation(currentSeg, transition);
        }
    }
}
