using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class actualfoesmove : MonoBehaviour
{
    public float m_CloseDistance = 8f;

    private GameObject m_player;
    private NavMeshAgent m_NavAgent;
    // private Rigidbody m_Rigidbody;

    private bool m_Follow;
    private Vector3 place;

    void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        //m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
        place = transform.position;
    }

    private void OnEnable()
    {
        //m_Rigidbody.isKinematic = false;
        transform.position = place;
    }

    private void OnDisable()
    {
        //  m_Rigidbody.isKinematic = true;
        m_Follow = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = false;
        }
    }

    void Update()
    {
        if (m_Follow == false)
        {

            if (transform.position != place)
            {
                m_NavAgent.SetDestination(place);
                m_NavAgent.isStopped = false;
                return;
            }
            else
            {
                return;
            }

        }


        float distance = (m_player.transform.position - transform.position).magnitude;

        
          m_NavAgent.SetDestination(m_player.transform.position);
          m_NavAgent.isStopped = false;
        

    }
}
