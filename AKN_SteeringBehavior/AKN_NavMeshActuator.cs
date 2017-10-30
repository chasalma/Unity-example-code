using UnityEngine;
using System.Collections;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_NavMeshActuator : AKN_VelocityActuator
    {
        private NavMeshAgent _m_agent;
        public Vector3 m_goal;

        public AKN_NavMeshActuator(NavMeshAgent _agent, Vector3 _goal)
            : base("NavMesh",_agent.gameObject)
        {
            _m_agent= _agent;
             m_goal = _goal; 
        }

        public override AKN_Status MUpdate()
        {
            _m_agent.destination = m_goal;
          _m_force = _m_agent.velocity;

          if (_m_force.sqrMagnitude < AKeNe.Math.AKN_Math.m_epsilon)
            {
                _m_force = Vector3.zero ;
                return AKN_Status.m_Success;
            }
            
            else
            {
                return AKN_Status.m_Failure;
            }
        }
    }
}