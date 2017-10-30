using UnityEngine;
using System.Collections;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_SeekActuator : AKN_VelocityActuator
    {
       
        #region Attribut

        /**************************************************************************************************
         * \summary The real goal .
         **************************************************************************************************/

        private Vector3 _m_goalReal;

        /**************************************************************************************************
         * \summary The goal inside a circle with the center is the real goal.
         **************************************************************************************************/

        private Vector3 _m_goal; 
        public Vector3 m_goal
        {
            set
            {
                if (m_is2D)
                {
                    _m_goalReal = value;
                    Vector2 rand = Random.insideUnitCircle * m_radius;
                    _m_goal = _m_goalReal + new Vector3(rand.x, 0f, rand.y);
                }
                else
                {
                    _m_goalReal = value;
                    _m_goal = _m_goalReal + Random.insideUnitSphere * m_radius;
                }
            }
            get
            {
                return _m_goal;
            }
        }

        /**************************************************************************************************
         * \summary The radius of a circle .
         **************************************************************************************************/

        public float m_radius;

        /**************************************************************************************************
         * \summary The default radius of a circle.
         **************************************************************************************************/

        public static float m_defaultRadius = 5f;
        #endregion

        #region Constructeur
        public AKN_SeekActuator(GameObject _gameObject) : this(_gameObject, Vector3.zero, m_defaultRadius) { }

        public AKN_SeekActuator(GameObject _gameObject, Vector3 _goal) : this(_gameObject, _goal, m_defaultRadius) { }

        public AKN_SeekActuator(GameObject _gameObject, float _radius) : this(_gameObject, Vector3.zero, _radius) { }

        public AKN_SeekActuator(GameObject _gameObject, Vector3 _goal, float _radius)
            : base("Seek", _gameObject)
        {
            m_radius = _radius;
            m_goal = _goal;
        }
        #endregion

        public new void MDraw()
        {
            base.MDraw();
            Gizmos.color = Color.grey;
            Gizmos.DrawSphere(_m_goal, 0.1f);
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(_m_goalReal, 0.1f);
            Gizmos.DrawWireSphere(_m_goalReal, m_radius);
        }

        public override AKN_Status MUpdate()
        {
            Vector3 position = m_gameObject.transform.position;
            if ((m_goal - position).sqrMagnitude < AKeNe.Math.AKN_Math.m_epsilon)
            {
                return AKN_Status.m_Success;
            }
            else
            {
                _m_force = m_goal - position;
                return AKN_Status.m_Failure;
            }
            
        }
    }
}