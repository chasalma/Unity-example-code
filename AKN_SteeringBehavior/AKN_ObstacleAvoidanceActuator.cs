using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_ObstacleAvoidanceActuator : AKN_VelocityActuator
    {
        #region Attributs
        public static float m_defaultRadius = 2f;
        private float _m_radius;
        //  private string _m_ObstacleTag;
        //private List<GameObject> _m_ObstaclesList;
        public float ObstacleAvoidanceForce = 4f;                                  //higher => more effect from this behaviour
        public float ObstacleAvoidanceForceFactorDuringWander = 8f;
        #endregion

        #region Constructeur
        /*  public AKN_ObstacleAvoidanceActuator(GameObject _gameObject, float _radius , string _ObstacleTag)
        : base("Obstacle Avoidance", _gameObject)
    {
        _m_radius = _radius;
        _m_ObstacleTag = _ObstacleTag;
    }*/
        public AKN_ObstacleAvoidanceActuator(GameObject _gameObject, float _radius)
            : base("Obstacle Avoidance", _gameObject)
        {
            _m_radius = _radius;
        }
        public AKN_ObstacleAvoidanceActuator(GameObject _gameObject) : this(_gameObject, m_defaultRadius) { }
        #endregion


        //public void SetObstacle(List<GameObject> _Obstacle)
        // {
        //     _m_ObstaclesList.Clear();
        //     foreach (GameObject Go in _Obstacle)
        //     {
        //         if (Go.transform.tag == _m_ObstacleTag)
        //         {
        //             _m_ObstaclesList.Add(Go);
        //         }
        //     }
        // }

        /**************************************************************************************************
         * Calculate the avoidance force.
         *
         * \author Chaabane Salma
         * \date 12/06/2012
         *
         * \param myHit my hit.
         *
         * \return .
         **************************************************************************************************/

        private Vector3 _MCalculAvoidanceForce(RaycastHit _hit)
        {
            Vector3 force = Vector3.zero;
            force += (_m_gameObject.transform.position - _hit.point).normalized / _hit.distance;
            return force;
        }

        /**************************************************************************************************
         * Obstacle detection.
         *
         * \author Chaabane Salma
         * \date 12/06/2012
         *
         * \param myDirection my direction.
         * \param [out] myHit my hit.
         * \param _raidus     The raidus.
         *
         * \return true if it succeeds, false if it fails.
         **************************************************************************************************/

        private bool _MDetectObstacle(Vector3 _direction, out RaycastHit _hit, float _raidus)
        {
            if (Physics.Raycast(_m_gameObject.transform.position, _direction, out _hit, _raidus))
            {
                if (_hit.transform.tag == "Terrain")
                {
                    return false;
                }
                else if (_hit.collider.isTrigger)
                {

                }
                else
                    Debug.DrawLine(_m_gameObject.transform.position, _hit.point, Color.red);
                return true;
            }
            return false;
        }


        public override AKN_Status MUpdate()
        {

            Vector3 ForceLeft = Vector3.zero;
            Vector3 ForceRight = Vector3.zero;
            Vector3 ForceMiddle = Vector3.zero;

            Vector3 directionLeft = 2 * _m_gameObject.transform.forward - _m_gameObject.transform.right;
            Vector3 directionRight = 2 * _m_gameObject.transform.forward + _m_gameObject.transform.right;
            Vector3 directionMiddle = _m_gameObject.transform.forward;

            RaycastHit hitRight;
            RaycastHit hitLleft;
            RaycastHit hitMiddle;

            bool ObstacleLeft = _MDetectObstacle(directionLeft, out hitLleft, _m_radius);
            bool ObstacleRight = _MDetectObstacle(directionRight, out hitRight, _m_radius);
            bool ObstacleMiddle = _MDetectObstacle(directionMiddle, out hitMiddle, _m_radius);


            if (ObstacleLeft || ObstacleRight || ObstacleMiddle)
            {
                if (ObstacleLeft)
                {
                    ForceLeft = _MCalculAvoidanceForce(hitLleft);
                }
                if (ObstacleRight)
                {
                    ForceRight = _MCalculAvoidanceForce(hitRight);
                }
                if (ObstacleMiddle)
                {
                    ForceMiddle = _MCalculAvoidanceForce(hitMiddle);
                }
                if (ForceLeft != Vector3.zero && ForceRight != Vector3.zero && ForceMiddle == Vector3.zero)
                {
                    _m_force = Vector3.zero;
                }
                else if ((ForceLeft != Vector3.zero || ForceRight != Vector3.zero || ForceMiddle != Vector3.zero))
                {
                    _m_force = ObstacleAvoidanceForceFactorDuringWander * (0.5f * ForceLeft + 0.5f * ForceRight + ForceMiddle);
                }
                else
                {
                    _m_force = ObstacleAvoidanceForce * (ForceLeft + ForceRight + ForceMiddle);
                }
                return AKN_Status.m_Success;
            }
            else
            {
                _m_force = Vector3.zero;
                return AKN_Status.m_Failure;
            }
        }
    }
}
