using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject Door;
    public Animator animator;

    private bool inRange = false;
    private bool doorOpen = false;

    private void Update()
    {
        animator.SetBool("DoorOpen", doorOpen);
        animator.SetBool("InRange", inRange);

        if (Input.GetKeyDown("e"))
        {
            if (inRange == true && doorOpen == false)
            {
                doorOpen = true;
            }
            else if (inRange == true && doorOpen == true)
            {
                doorOpen = false;
            }
        }
    }
}
