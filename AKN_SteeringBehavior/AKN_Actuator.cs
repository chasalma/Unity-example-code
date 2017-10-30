using UnityEngine;
using System.Collections;
namespace AKeNe.AI.SteeringBehavior
{
    public abstract class AKN_Actuator : AKN_Base, AKeNe.Kernel.AKN_IUpdatable
    {

        protected GameObject _m_gameObject;
        public GameObject m_gameObject
        {
            get
            {
                return _m_gameObject;
            }
        }

        public AKN_Actuator(GameObject _gameObject)
            : base()
        {
            _m_gameObject = _gameObject;
        }

        public AKN_Actuator(string _label, GameObject _gameObject)
            : base(_label)
        {
            _m_gameObject = _gameObject;
        }
        abstract public void MDraw();
        abstract public AKN_Status MUpdate() ;
    }
}
