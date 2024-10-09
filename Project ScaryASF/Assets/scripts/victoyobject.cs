using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoyobject : MonoBehaviour
{
    public gamemanager gamemanager;
    private bool in_area = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && in_area == true)
        {
            gamemanager.objectivesCollected++;
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
