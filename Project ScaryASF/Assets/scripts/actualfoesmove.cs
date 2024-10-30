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

    public bool playerInvisible = false;
    private bool m_Follow;
    private GameObject place;

    private Vector3 target;

    public gamemanager manager;

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
        if (playerInvisible == true)
        {
            StartCoroutine(disableInvis());
        }

        if (manager.ableToWin == true)
        {
            m_Follow = true;
        }

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

        }
        else
        {

            float distance = (m_player.transform.position - transform.position).magnitude;


            m_NavAgent.SetDestination(m_player.transform.position);
        }

        m_NavAgent.isStopped = false;
    }

    IEnumerator disableInvis()
    {
        m_Follow = false;
        yield return new WaitForSeconds(8);
        playerInvisible = false;
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

    private void OnTriggerStay(Collider other)
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

        destPoint = (destPoint++) % points.Length;
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
