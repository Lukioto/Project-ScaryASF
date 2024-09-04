using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject Door;
    public Animator animator;

    private bool inRange;
    private bool doorOpen;
    private bool playerInput;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }
    private void Update()
    {
        animator.SetBool("DoorOpen", doorOpen);
        animator.SetBool("InRange", inRange);
        animator.SetBool("PlayerInput", playerInput);

        if (Input.GetKeyDown("e"))
        {
            playerInput = true;
            if (doorOpen == false)
            {
                doorOpen = true;
            }
            else if (doorOpen == true)
            {
                doorOpen = false;
            }
        }
    }
}
