using UnityEngine;
using System.Collections;
namespace AKeNe.AI.SteeringBehavior
{
    /**************************************************************************************************
     * <summary>Akn sensor base.</summary>
     * classe abstraite de base
     * <remarks>Chaabane Salma, 16/05/2012.</remarks>
     **************************************************************************************************/

    public abstract class AKN_Sensor_Base : AKN_Base, AKeNe.Kernel.AKN_IUpdatable
    {
        #region Attribut
        
        protected GameObject _m_gameobject;
        public GameObject m_gameobject
        {
            set
            {
                _m_gameobject = value;
            }
            get
            {
                return _m_gameobject;
            }
        }

        /**************************************************************************************************
         * \summary m_Active is true when the sensor is start, to trigger the actuator .
         **************************************************************************************************/

        public bool m_Active;
        #endregion
        public AKN_Sensor_Base()
            : base(){ }
        public AKN_Sensor_Base(string _label)
            : base(_label){ }
        abstract public AKN_Status MUpdate();
        abstract public void MDraw();
        abstract public void MInit();
        
    }
}

