using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class Deplacement : MonoBehaviour
{
    public GameObject m_Goal;
    public float m_Speed = 0.1f;
    Animator _m_animator;
    NavMeshAgent _m_Agent;
    // Use this for initialization
    void Start()
    {
        _m_Agent = GetComponent<NavMeshAgent>();
        _m_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _m_animator.SetBool("m_Walk", true);
        _m_Agent.destination = m_Goal.transform.position;
        _m_Agent.speed = m_Speed;
    }
}

