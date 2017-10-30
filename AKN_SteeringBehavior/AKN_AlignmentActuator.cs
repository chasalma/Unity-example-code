using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_AlignmentActuator : AKN_GroupActuator
    {
        #region Attribut
        
        private Vector3 _m_Direction;
        public Vector3 m_Direction
        {
            get
            {
                return _m_Direction;
            }
        }
        #endregion

        public AKN_AlignmentActuator(GameObject _gameObject)
            : base("Alignment", _gameObject)
        {

            _m_force = Vector3.zero;
        }
        public override void MSetNeighbors(List<GameObject> _neighbors)
        {
            _m_NeighborsObject.Clear();
            foreach (GameObject go in _neighbors)
            {
                if (go.layer == _m_gameObject.layer)  // only object in the same layer
                {
                    _m_NeighborsObject.Add(go.transform.forward);
                }
               
            }
        }
        public override AKN_Status MUpdate()
       {
           if (_m_NeighborsObject.Count > 0)
           {
               foreach (Vector3 v in _m_NeighborsObject)
               {
                   _m_Direction += v;
               }
               _m_Direction += _m_gameObject.transform.forward;
               _m_Direction /= (_m_NeighborsObject.Count + 1);
               _m_force = _m_Direction;
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


