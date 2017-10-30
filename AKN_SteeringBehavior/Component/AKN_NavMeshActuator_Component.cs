using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_NavMeshActuator_Component : AKN_VelocityActuator_Component
{

    private  NavMeshAgent m_agent;

    public void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_actuator = new AKN_NavMeshActuator(m_agent, m_goal.transform.position);
    }
    new void Start()
    {
       
	}
 /*   void OnDrawGizmos()
    {
        if (_m_navmeshActuator != null)
        {
            _m_navmeshActuator.MDraw();
        }
    }*/

    new void Update()
    {
        ((AKN_NavMeshActuator)m_actuator).m_goal = m_goal.transform.position;
        m_agent.speed = m_velocity;
        ((AKN_NavMeshActuator)m_actuator).MUpdate();
       
	}
}
