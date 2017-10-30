using UnityEngine;
using System.Collections;
using System.Collections.Generic ;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_Sensor<T> : AKN_Sensor_Base 
    {
        protected T _m_output;
        public T m_output
        {
            get
            {
                return _m_output;
            }
            set
            {
                _m_output = value;
            }

        }
        public AKN_Sensor(GameObject _gameObject)
            : base() {
                m_Active = false;
                _m_gameobject = _gameObject;
            }


        public AKN_Sensor(string _label, GameObject _gameObject)
            : base(_label) {
                m_Active = false;
                _m_gameobject = _gameObject;
            }
		  public override AKN_Status MUpdate()
        {
            return AKN_Status.m_Failure;
        }
       
        public override void MInit()
        {
            m_Active = false;
        }
        public override void MDraw() { }
      
       
    }
}