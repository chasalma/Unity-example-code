using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_SAN 
    {
       
   #region Attribut

        public class SAPair
        {
            public AKN_Actuator actuator;
            public float coefficient;
            public AKN_Sensor_Base sensor;
        }
        private GameObject _m_GameObject;
        float _m_sommeCoef;
        /**************************************************************************************************
         * \summary SAPairList is a List of sensor actuator pairs.  
         **************************************************************************************************/

        public List<SAPair> m_SAPairList;

        /**************************************************************************************************
         * \summary The average force. (la moyenne des forces)
         **************************************************************************************************/

        public Vector3 m_AverageForce;
       
        #endregion
	
        public AKN_SAN(GameObject _gameobject)
        {
            m_AverageForce = Vector3.zero;
            m_SAPairList = new List<SAPair>();
            _m_GameObject = _gameobject;

        }

        /**************************************************************************************************
         * Adds a sensor actuator pair .
         * make a link between sensor and actuator
         * \author Chaabane Salma
         * \date 18/05/2012
         *
         * \param _sensor   The sensor.
         * \param _actuator The actuator.
         **************************************************************************************************/
        public void MAddActuatorOnly(AKN_Actuator _actuator , float _coefficient) 
        {
            
            SAPair _sapair = new SAPair();
            _sapair.sensor = null;
            _sapair.actuator = _actuator;
            _sapair.coefficient = _coefficient;
            m_SAPairList.Add(_sapair);
        }
        public void MAddSAPair(AKN_Sensor_Base _sensor, AKN_Actuator _actuator , float _coefficient) 
        {
            SAPair _sapair = new SAPair();
            _sapair.sensor = _sensor;
            _sapair.actuator = _actuator;
            _sapair.coefficient = _coefficient;
            m_SAPairList.Add(_sapair);
         
        }


        public AKN_Status MUpdate()
        {
            m_AverageForce = Vector3.zero;
            _m_sommeCoef = 0f;
			
            if (m_SAPairList.Count > 0)
            {
                int _count = 0;
                foreach (SAPair sa in m_SAPairList)
                {
					
					
                    List<GameObject> output = new List<GameObject>();
                    Vector3 ForceSmart;
                    if (sa.sensor == null)
                    {
                     //   Debug.Log(_m_GameObject.name + " actuator update " + sa.actuator.m_label);
                        sa.actuator.MUpdate();
                     /*   if (((AKN_VelocityActuator)sa.actuator).m_force != Vector3.zero && sa.actuator.m_label == "Obstacle Avoidance")
                        {
                       //     Debug.Log(_m_GameObject.name + " actuator force " + ((AKN_VelocityActuator)sa.actuator).m_force);
                        }*/
                        m_AverageForce += ((AKN_VelocityActuator)sa.actuator).m_force * sa.coefficient;
                        _m_sommeCoef += sa.coefficient;
                        _count++;
                    }
                    else
                    {
                        sa.sensor.MUpdate();
                        
                        if (sa.sensor.m_label == "Amer")
                         {
                             if (sa.sensor.m_Active)
                             {
                                 sa.actuator.MUpdate();
                                 m_AverageForce += ((AKN_VelocityActuator)sa.actuator).m_force * sa.coefficient;
                                 _m_sommeCoef += sa.coefficient;
                                 _count++;
                             }
                            }

                        else
                            if (sa.sensor.m_label == "Smart Terrain")
                            {
                                Vector3 smart = ((AKN_SmartTerrainSensor)sa.sensor).m_output;
                                if (smart != null)
                                {
                                    ForceSmart = smart;
                                }
                            }
                            else
                            {
                                List<GameObject> listGO = ((AKN_GameObjectSensor)sa.sensor).m_output;
                                if (listGO != null)
                                {
                                    output = listGO;
                                }



                                if (sa.sensor.m_Active)
                                {
                                    if (sa.actuator.m_label.Equals("Alignment") || sa.actuator.m_label.Equals("Cohesion") || sa.actuator.m_label.Equals("Separation"))
                                        ((AKN_GroupActuator)sa.actuator).MSetNeighbors(output);
                                    sa.actuator.MUpdate();
                                    m_AverageForce += ((AKN_VelocityActuator)sa.actuator).m_force * sa.coefficient;
                                    _m_sommeCoef += sa.coefficient;
                                    _count++;

                                }
                            }
                    }
                   
                }
                if (_count > 0)
                {
                  //  m_AverageForce = m_AverageForce / _count;
                    m_AverageForce = m_AverageForce / _m_sommeCoef;
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
