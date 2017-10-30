using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AKeNe.AI.SteeringBehavior
{
    public abstract class AKN_GroupActuator : AKN_VelocityActuator
    {
        protected List<Vector3> _m_NeighborsObject;
        
        public AKN_GroupActuator(string _label, GameObject _gameObject)
            : base(_label, _gameObject)
        {
            _m_NeighborsObject = new List<Vector3>();
        }

        public abstract void MSetNeighbors(List<GameObject> _neighbors);
        
	}
}
