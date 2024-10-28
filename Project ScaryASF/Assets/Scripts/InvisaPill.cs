using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisaPill : MonoBehaviour
{
    public actualfoesmove actualFoesMove;
    private bool in_area = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && in_area == true)
        {
            actualFoesMove.playerInvisible = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            in_area = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            in_area = false;
        }
    }
}
