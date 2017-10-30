using UnityEngine;
using System.Collections;

namespace AKeNe.AI.SteeringBehavior
{
	public class AKN_ArriveActuator  : AKN_VelocityActuator 
	{
        private Vector3 _m_Target;
        public float m_arriveRadius ;//= 6;
        public float m_arriveDamping;// = 5;  
        public float m_maxForce;
        public AKN_ArriveActuator(GameObject _gameObject)
            : base("Arrive", _gameObject)
        {
        }
        public AKN_ArriveActuator(GameObject _gameObject, Vector3 _target)
            : base("Arrive", _gameObject)
        {
            _m_Target = _target;
        }
        public override AKN_Status MUpdate()
        {
         /*   Vector3 position = m_gameObject.transform.position;
            if ((_m_Target - position).sqrMagnitude < AKeNe.Math.AKN_Math.m_epsilon)
            {
                return AKN_Status.m_Success;
            }
            else
            {
                _m_force = _m_Target - position;
                return AKN_Status.m_Failure;
            }*/
            Vector3 position = m_gameObject.transform.position;
            float distanceToTarget = Vector3.Distance(_m_Target, position);
            float scale = 0; 
            
            if (distanceToTarget > m_arriveRadius) //decrease acceleration
            {
                scale = m_maxForce * ((distanceToTarget - m_arriveRadius) / distanceToTarget);
                _m_force = (_m_Target - position).normalized * scale;
                return AKN_Status.m_Success;
            }
            else
            {
                _m_force = _m_Target - position;
                //scale = 0;
                //_m_force = (_m_Target - position).normalized * scale;
                return AKN_Status.m_Failure;
            }
            //else//come to halt
            //{
            //    scale = 0; //no more accelerations
            //    velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime * m_arriveDamping); //go to zero in some time
            //}
           // _m_force = (_m_Target - position).normalized * scale; //look at target direction, normalized and scaled
           // Debug.DrawLine(position, _m_Target, Color.blue);
            

        }
	}
}
