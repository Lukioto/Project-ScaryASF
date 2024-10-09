using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolpoints : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sock")
        {
            
            gameObject.SetActive(false);

        }

    }

}
