using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class actualfoesmove : MonoBehaviour
{
    private int activepoint;
    public GameObject[] points;

    private GameObject m_player;
    private NavMeshAgent m_NavAgent;
    // private Rigidbody m_Rigidbody;

    private bool m_Follow;
    private GameObject place;

    void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        //m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }

    private void OnEnable()
    {
        //m_Rigidbody.isKinematic = false;
        transform.position = place.transform.position;
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

    public void newpatrolpoint()
    {
        points[activepoint].SetActive(true);
    }

    void Update()
    {

        place = GameObject.FindGameObjectWithTag("victory");

        if (m_Follow == false)
        {
            m_NavAgent.SetDestination(place.transform.position);

            /*if (transform.position != place)
            {
                m_NavAgent.SetDestination(place);
                m_NavAgent.isStopped = false;
                return;
            }
            else
            {
                return;
            }
            */
        }


        float distance = (m_player.transform.position - transform.position).magnitude;

        
          m_NavAgent.SetDestination(m_player.transform.position);
          m_NavAgent.isStopped = false;
        

    }
}
