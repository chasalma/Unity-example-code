using UnityEngine;
using System.Collections;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_FleeActuator : AKN_VelocityActuator
    {
        #region Attribut
        private Vector3 _m_EnnemiePosition;
        public Vector3 m_EnnemiePosition
        {
            set
            {
                _m_EnnemiePosition = value;
            }
            get
            {
                return _m_EnnemiePosition;
            }
        }

        public float m_radius;
        public static float m_defaultRadius = 5f;
        #endregion

        public AKN_FleeActuator(GameObject _gameObject) : this(_gameObject, m_defaultRadius, _gameObject.transform.position) { }
        public AKN_FleeActuator(GameObject _gameObject ,float _radius ) : this(_gameObject, m_defaultRadius, _gameObject.transform.position) { }

        public AKN_FleeActuator(GameObject _gameObject, float _radius , Vector3 _EnnemiePosition)
            : base("Flee", _gameObject)
        {
            m_radius = _radius;
            _m_EnnemiePosition = _EnnemiePosition;
        }

        new public void MDraw()
        {
            base.MDraw();
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(_m_EnnemiePosition, 0.1f);
            Gizmos.DrawWireSphere(_m_EnnemiePosition, m_radius);
        }

        new public AKN_Status MUpdate()
        {
            float distance = Vector3.Distance(m_gameObject.transform.position, _m_EnnemiePosition); //distance to target
            _m_force = Vector3.zero;
            if (distance < m_radius) //if close enough
            {
                _m_force = (m_gameObject.transform.position - _m_EnnemiePosition).normalized  / distance; //look away from target direction, normalized and scaled
                return AKN_Status.m_Failure;
            }
            else
            {
                return AKN_Status.m_Success;
            }
         }
    }
}
