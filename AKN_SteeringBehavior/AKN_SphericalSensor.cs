using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_SphericalSensor : AKN_GameObjectSensor
    {
        /**************************************************************************************************
         * \summary The m_dov distance of view.
         **************************************************************************************************/
        private float _m_dov;
        public float m_dov
        {
            get
            {
                return _m_dov;
            }
        }
        /**************************************************************************************************
         * Constructor.
         *
         * \author Chaabane Salma
         * \date 18/05/2012
         *
         * \param _gameObject The game object.
         * \param _distance   The distance.
         **************************************************************************************************/

        public AKN_SphericalSensor(GameObject _gameObject, float _distance)
            : base("Spherical Sensor", _gameObject)
        {
            _m_dov = _distance;
            _m_output = new List<GameObject>();
           
        }
        public AKN_SphericalSensor(GameObject _gameObject, float _distance , string _label)
            : base(_label, _gameObject)
        {
            _m_dov = _distance;
            _m_output = new List<GameObject>();

        }

        /**************************************************************************************************
         * Updates this object.
         *
         * \author Chaabane Salma
         * \date 18/05/2012
         *
         * \return .
         **************************************************************************************************/

        public override AKN_Status MUpdate()
        {

            _m_output.Clear();
            Collider[] _colliders = Physics.OverlapSphere(m_gameobject.transform.position, _m_dov);
            if (_colliders.Length <=1  )
            {
                m_Active = false;
                //Debug.Log("pas de collision"); 
                return AKN_Status.m_Failure; 
            }
            else
            {
                m_Active = true;
                foreach (Collider c in _colliders)
                {
                    if (c.gameObject != _m_gameobject )
                        _m_output.Add(c.gameObject);
                }
             
                return AKN_Status.m_Success; 
            }  
        }
       
    }
}