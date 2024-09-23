using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFinalDoorLeft : MonoBehaviour
{
    public GameObject Door;
    public Animator animator;
    public gamemanager gamemanager;

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
        animator.SetBool("FinalDoorOpen", doorOpen);
        animator.SetBool("FinalInRange", inRange);
        animator.SetBool("FinalPlayerInput", playerInput);

        if (Input.GetKeyDown("e") && inRange == true)
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

