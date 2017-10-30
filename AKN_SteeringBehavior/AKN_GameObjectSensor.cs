using System;
using UnityEngine;
using System.Collections.Generic;

namespace AKeNe.AI.SteeringBehavior
{
    public abstract class AKN_GameObjectSensor : AKN_Sensor<List<GameObject>>
	{
        public AKN_GameObjectSensor(string _label, GameObject _gameObject) : base(_label, _gameObject) { }

        public GameObject MElementAt(int _index)
        {
            return m_output[_index] as GameObject;
        }
    }
}
