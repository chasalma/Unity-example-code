
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_CohesionActuator : AKN_GroupActuator
    {
        #region Attribut
      
        Vector3 _m_CentorOfMass;
        #endregion

        public AKN_CohesionActuator(GameObject _gameObject)
            : base("Cohesion", _gameObject)
        {
        }
        public override void MSetNeighbors(List<GameObject> _neighbors)
        {
            _m_NeighborsObject.Clear();
            foreach ( GameObject go in _neighbors)
            {
                if (go.layer == _m_gameObject.layer)  // only object in the same layer
                {
                    _m_NeighborsObject.Add(go.transform.position);
                }
            }
            
        }
        public override AKN_Status MUpdate()
        {
            Vector3 position = m_gameObject.transform.position;
            _m_CentorOfMass = Vector3.zero;
            if (_m_NeighborsObject.Count > 0)
            {
                foreach (Vector3 v in _m_NeighborsObject)
                {
                    _m_CentorOfMass += v;
                }
                _m_CentorOfMass /= _m_NeighborsObject.Count;
                _m_force = _m_CentorOfMass - position;
                return AKN_Status.m_Success;
            }
            else
            {
                _m_force = position;
                return AKN_Status.m_Failure;
            }
        }
    }
}
