using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AKeNe.AI.SteeringBehavior;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_AmerSensor : AKN_Sensor<float>
    {
        #region Attribut

        /**************************************************************************************************
         * \summary The name of amer.
         **************************************************************************************************/

        public string m_Name;

        /**************************************************************************************************
         * \summary The current value.
         **************************************************************************************************/

        private float _m_Value;
        public float m_Value
        {
            get
            {
                return _m_Value;
            }
        }

        /**************************************************************************************************
         * \summary The speed of decrease.
         **************************************************************************************************/

        public float m_Speed;

        /**************************************************************************************************
         * \summary The maximum value.
         **************************************************************************************************/

        private float _m_MaxValue;

        /**************************************************************************************************
         * \summary The minimum value.
         **************************************************************************************************/

        private float _m_MinValue;

        /**************************************************************************************************
         * \summary The message to send.
         **************************************************************************************************/

        private string _m_Message;
        #endregion

        /**************************************************************************************************
         * Constructor.
         *
         * \author Chaabane Salma
         * \date 18/05/2012
         *
         * \param _name       The name.
         * \param _maxValue   The maximum value.
         * \param _minValue   The minimum value.
         * \param _speed      The speed.
         * \param _gameobject The game object.
         * \param _message    The message.
         **************************************************************************************************/

        public AKN_AmerSensor(string _name, float _maxValue, float _minValue, float _speed, GameObject _gameobject, string _message)
            : base("Amer", _gameobject)
        {
            m_Name = _name;
            _m_MaxValue = _maxValue;
            _m_Value = _maxValue;
            _m_MinValue = _minValue;
            _m_Message = _message;
            m_Speed = _speed;
        }

        /**************************************************************************************************
         * Initialises this object.
         *
         * \author Chaabane Salma
         * \date 18/05/2012
         **************************************************************************************************/

        public override  void MInit()
        {
            m_Active = false;
            _m_Value = _m_MaxValue;
        }

        /**************************************************************************************************
         * Up date.
         * decrease the value  until this value lower than the min value
         * send the message
         * and active the sensor to trigger the actuator
         * \author Chaabane Salma
         * \date 18/05/2012
         **************************************************************************************************/

        public override AKN_Status MUpdate()
        {
            if (!m_Active)
            {
                _m_Value = _m_Value - Time.deltaTime * m_Speed;
               // Debug.Log("valeur " + _m_Value);
                if (_m_Value < _m_MinValue)
                {
                    Debug.Log(_m_Message);
                   // m_gameobject.SendMessage(_m_Message);
                    m_Active = true;
                    return AKN_Status.m_Success;
                }
                else
                    return AKN_Status.m_Failure;
            }
            else
                return AKN_Status.m_Failure;
        }
    }
}
