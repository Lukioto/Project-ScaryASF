using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapitem : MonoBehaviour
{

    private bool in_area = false;
    public playermovement move;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && in_area == true)

        {
            move.hasneedle = true;
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
