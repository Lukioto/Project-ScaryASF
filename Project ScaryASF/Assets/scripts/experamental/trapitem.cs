using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class trapitem : MonoBehaviour
{
    actualfoesmove move;
    GameObject sock;

    bool countdown = false;
    int timer = 10000;


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sock")
        {
            Debug.Log("check");
            move.m_NavAgent.speed = 0;
            countdown = true;


        }
    }*/

    private void Awake()
    {
        sock = GameObject.FindGameObjectWithTag("sock");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, sock.transform.position) < 20)
        {


            if (countdown == true)
            {
                if (timer == 0)
                {
                    countdown = false;
                    timer = 10000;
                }
                else
                {
                    timer -= 1;

                }

            }
        }
    }
}
