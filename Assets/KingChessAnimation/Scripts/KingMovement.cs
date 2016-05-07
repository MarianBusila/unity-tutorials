using UnityEngine;
using System.Collections;

public class KingMovement : MonoBehaviour {
    private Animator anim;
    int hIdle;
    int hForward;
    int hBack;
    int hLeft;
    int hRight;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        hIdle = Animator.StringToHash("Idle");
        hForward = Animator.StringToHash("Forward");
        hBack = Animator.StringToHash("Back");
        hLeft = Animator.StringToHash("Left");
        hRight = Animator.StringToHash("Right");
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.W))
        {
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetBool(hIdle, false);
                anim.SetBool(hForward, true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetBool(hIdle, false);
                anim.SetBool(hBack, true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetBool(hIdle, false);
                anim.SetBool(hLeft, true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetBool(hIdle, false);
                anim.SetBool(hRight, true);
            }
        }
        else
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                anim.SetBool(hIdle, true);
                anim.SetBool(hForward, false);
                anim.SetBool(hBack, false);
                anim.SetBool(hLeft, false);
                anim.SetBool(hRight, false);
            }
        }

    }
}
