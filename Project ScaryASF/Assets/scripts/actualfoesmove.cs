using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class actualfoesmove : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;

    private GameObject m_player;
    public NavMeshAgent m_NavAgent;
    // private Rigidbody m_Rigidbody;

    private bool m_Follow;
    private GameObject place;

    private Vector3 target;

    void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent<NavMeshAgent>();
        //m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
        NextPoint();

        m_NavAgent.autoBraking = false;
    }

    void Update()
    {



        if (m_Follow == false)
        {
            if (Vector3.Distance(transform.position, target) < 1)
            {
                potralpoint();
                NextPoint();

            }

            if (!m_NavAgent.pathPending && !m_NavAgent.hasPath && m_NavAgent.remainingDistance < 0.1f)
            {
                potralpoint();
                NextPoint();
            }

            /*
            m_NavAgent.SetDestination(place.transform.position);
            m_NavAgent.isStopped = false;
            return;*/

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
        else
        {

            float distance = (m_player.transform.position - transform.position).magnitude;


            m_NavAgent.SetDestination(m_player.transform.position);
        }

        m_NavAgent.isStopped = false;


    }

    private void OnEnable()
    {
        //m_Rigidbody.isKinematic = false;
        transform.position = transform.position;
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
    void NextPoint()
    {
        if (points.Length == 0)
            return;


        m_NavAgent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    private void potralpoint()
    {
        destPoint++;
        if (destPoint == points.Length)
        {
            destPoint = 0;
        }
    }

}
