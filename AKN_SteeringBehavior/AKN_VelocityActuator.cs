using UnityEngine;
using System.Collections;
namespace AKeNe.AI.SteeringBehavior
{
public class AKN_VelocityActuator : AKN_Actuator {

   
        #region Attribut

        public bool m_is2D;

        protected Vector3 _m_force;
        public Vector3 m_force
        {
            get
            {
                return _m_force;
            }
        }
        public bool m_draw = true;
        #endregion

        public AKN_VelocityActuator(string _label, GameObject _gameObject)
            : this(_label, _gameObject,true)
        {        }
        public AKN_VelocityActuator(string _label, GameObject _gameObject, bool _is2D)
            : base(_label,_gameObject)
        {
            m_is2D = _is2D;
            _m_force = Vector3.zero;
        }

        public void MDrawForce()
        {
            Gizmos.DrawLine( _m_gameObject.transform.position, 
                _m_gameObject.transform.position + m_force); 
        }

       
        public override void MDraw()
        {
            MDrawForce();
        }
        public override AKN_Status MUpdate() { return AKN_Status.m_Failure; }
    }

}