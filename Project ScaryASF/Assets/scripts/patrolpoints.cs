using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolpoints : MonoBehaviour
{
    private actualfoesmove actualfoesmove;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sock")
        {
            actualfoesmove.newpatrolpoint();

            gameObject.SetActive(false);

        }

    }

}
