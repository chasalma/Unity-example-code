
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AKeNe.AI.SteeringBehavior;
public class AKN_SAN_Component : MonoBehaviour {

    private AKN_SAN _m_San;
    public float m_velocity = 4f;
    public List<AKN_Sensor_Component_Base> m_Sensors  = new List<AKN_Sensor_Component_Base>();
    public List<AKN_Actuator_Component_Base> m_Actuators  =  new List<AKN_Actuator_Component_Base>();
    public List<AKN_Actuator_Component_Base> m_ActuatorsOnly = new List<AKN_Actuator_Component_Base>();
 
    public int[] m_sensorIndex;
    public int[] m_actuatorIndex;
    public float[] m_coefActuator;
    public float[] m_coefActuatorOnly;
    public GameObject m_Goal;

    public void Start()
    {
       _m_San = new AKN_SAN(gameObject);

       for (int i = 0; i < m_sensorIndex.Length; i++)
       {
            _m_San.MAddSAPair(m_Sensors[m_sensorIndex[i]].m_Sensor, m_Actuators[m_actuatorIndex[i]].m_actuator, m_coefActuator[i]); 
       }
		
       int j = 0;
      foreach(AKN_Actuator_Component_Base actuator in m_ActuatorsOnly)
      {
          _m_San.MAddActuatorOnly(actuator.m_actuator, m_coefActuatorOnly[j]);
          j++;
       }
    
    }
   
    public void OnDrawGizmosSelected()
    {
        foreach (AKN_Actuator_Component_Base actu in m_Actuators)
        {
            AKN_Actuator actuator = actu.m_actuator;
            if (actuator != null)
            {
                switch (actuator.m_label)
                {
                    case "Alignment":
                        {
                            Gizmos.color = Color.red;
                        }
                        break;

                    case "Cohesion":
                        {
                            Gizmos.color = Color.green;
                        }
                        break;

                    case "Separation":
                        {
                            Gizmos.color = Color.black;
                        }
                        break;
                 
                    case "Flee":
                        {
                            Gizmos.color = Color.magenta;
                        }
                        break;
                    case "Pursuit":
                        {
                            Gizmos.color = Color.cyan;
                        }
                        break;
                   
                    default:
                        {
                            Gizmos.color = Color.white;
                        }
                        break;
                }
                actuator.MDraw();
            }
        }
       
        foreach (AKN_Actuator_Component_Base actu in m_ActuatorsOnly)
        {
            AKN_Actuator actuator = actu.m_actuator;
            if (actuator != null)
            {
                switch (actu.m_actuator.m_label)
                {
                    case "NavMesh":
                        {
                            Gizmos.color = Color.yellow;
                        }
                        break;
                    case "Seek":
                        {
                            Gizmos.color = Color.grey;
                        }
                        break;
                    case "Obstacle Avoidance":
                        {
                            Gizmos.color = Color.gray;
                        }
                        break;
                    case "Arrive":
                        {
                            Gizmos.color = Color.blue;
                        }
                        break;
                    default:
                        {
                            Gizmos.color = Color.black;
                        }
                        break;
                }

                actuator.MDraw();
            }
        }
    }
  
    public void Update() 
{
        Vector3 m_force ;
        foreach (AKN_Actuator_Component_Base actuator in m_ActuatorsOnly)
        {
            if (actuator.m_actuator.m_label == "NavMesh")
            {
                AKN_NavMeshActuator me = (AKN_NavMeshActuator)actuator.m_actuator as AKN_NavMeshActuator;
                if (me != null)
                {
                    me.m_goal = m_Goal.transform.position;
                }
            }
            if (actuator.m_actuator.m_label == "Seek")
            {
                AKN_SeekActuator me = (AKN_SeekActuator)actuator.m_actuator as AKN_SeekActuator;
                if (me != null)
                {
                    me.m_goal = m_Goal.transform.position;
                }
            }
        }
        if (_m_San.MUpdate())
        {
           
			for(int i = 0; i < m_coefActuator.Length; i++ )
			{
				_m_San.m_SAPairList[i].coefficient = m_coefActuator[i];
			}

            int j = m_coefActuator.Length;
            for (int i = 0; i < m_coefActuatorOnly.Length; i++)
            {
                _m_San.m_SAPairList[j].coefficient = m_coefActuatorOnly[i];
                j++;
            }

            m_force = _m_San.m_AverageForce;
            m_force = m_force.normalized * m_velocity;
           // if (m_force.x != 0 || m_force.x != 0)
           // {
                Quaternion rotation = Quaternion.LookRotation(new Vector3(m_force.x, 0, m_force.z), Vector3.up);
                transform.rotation = rotation;
           // }
            gameObject.transform.Translate(m_force.x * Time.deltaTime, 0, m_force.z * Time.deltaTime, Space.World);
           
        }
	}
}
