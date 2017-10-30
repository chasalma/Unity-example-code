using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_PursuitActuator_Component : AKN_VelocityActuator_Component
{
   
    public Vector3 _distanceSep = new Vector3(3, 3, 0);
    public void Awake()
    {
        m_actuator = new AKN_PursuitActuator(gameObject, m_goal);
    }
    new public void Start()
    {
    }
    
    new public  void Update()
    {
        ((AKN_PursuitActuator)m_actuator).MUpdate();
       
            m_force = ((AKN_PursuitActuator)m_actuator).m_force;
            if (m_force.sqrMagnitude > (m_velocity * m_velocity))
            {
                m_force = m_force.normalized * m_velocity;
            }
            m_force *= Time.deltaTime;
           /* Quaternion rotation = Quaternion.LookRotation(new Vector3(m_force.x, 0, m_force.z), Vector3.up);
            transform.rotation = rotation;
            gameObject.transform.Translate(m_force.x * Time.deltaTime, 0, m_force.z * Time.deltaTime, Space.World);*/
       
    }
}
