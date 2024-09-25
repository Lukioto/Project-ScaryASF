using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class OpenFinalDoorRight : MonoBehaviour
{
    public GameObject Door;
    public Animator animator;
    public gamemanager gamemanager;
    public TextMeshProUGUI cantWinYetText;

    private float disappearTime;
    private bool inRange;
    private bool doorOpen;

    private void Awake()
    {
        cantWinYetText.text = "Collect all objectives to open";
        cantWinYetText.enabled = false;
    }

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
        animator.SetBool("AbleToWin", gamemanager.ableToWin);

        if (Input.GetKeyDown("e") && inRange == true)
        {
            if (doorOpen == false && gamemanager.ableToWin == true)
            {
                doorOpen = true;
            }
            else if (doorOpen == false)
            {
                EnableText();
            }
        }

        if (cantWinYetText.enabled && (Time.time >= disappearTime))
        {
            cantWinYetText.enabled = false;
        }
    }
    public void EnableText()
    {
        cantWinYetText.enabled = true;
        disappearTime = Time.time + 1f;
    }
}


