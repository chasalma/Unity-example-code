using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_CollisionSensor : AKN_GameObjectSensor
    {

        public AKN_CollisionSensor()
            : this(null)
        {
        }
        public AKN_CollisionSensor(GameObject _gameObject)
            : base("Collision", _gameObject)
        {
            m_Active = false;
            m_output = new List<GameObject>();
        }

        public void MOnCollisionEnter(Collision _collision)
        {
            foreach (ContactPoint contact in _collision.contacts)
            {
                m_output.Add(_collision.gameObject);
            }

            m_Active = true;
        }
    }
}
