using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class slowbadguy : MonoBehaviour
{

    public NavMeshAgent movement;

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "sock")
       {
            movement.speed = 5;
       }
    }
}
