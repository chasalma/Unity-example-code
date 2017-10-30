using UnityEngine;
using System.Collections;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_PursuitActuator : AKN_VelocityActuator
    {  /**************************************************************************************************
         * \summary The game object to pursuit.
         **************************************************************************************************/

        private GameObject _m_gameobjectPursuit;
        public GameObject m_gameobjectPursuit
        {
            get
            {
                return _m_gameobjectPursuit;
            }
        }

        public AKN_PursuitActuator(GameObject _gameObject , GameObject _GOtopursuit)
            : base("Pursuit", _gameObject)
        {
            _m_gameobjectPursuit = _GOtopursuit;
        }
        public override AKN_Status MUpdate()
        {
            Vector3 position = m_gameObject.transform.position;
            Vector3 m_goal = _m_gameobjectPursuit.transform.position;
            if ((m_goal - position).sqrMagnitude < AKeNe.Math.AKN_Math.m_epsilon)
            {
                return AKN_Status.m_Success;
            }
            else
            {
                _m_force = m_goal - position;
                return AKN_Status.m_Success;
            }
        }
	}
}
