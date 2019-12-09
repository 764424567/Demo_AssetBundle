using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test_nav : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    public GameObject m_Target;
    // Use this for initialization
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Agent.SetDestination(m_Target.transform.position);
    }
}
