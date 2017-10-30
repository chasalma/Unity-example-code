using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AKeNe.AI.SteeringBehavior;
public class AKN_AlignmentActuator_Component : AKN_VelocityActuator_Component
{
    private AKN_SphericalSensor _m_sphericalsensor;
    /*Vector3 directionR;
    Vector3 directionB;
    Vector3 directionV;*/
    // Use this for initialization
    public void Awake()
    {
		        m_actuator = new AKN_AlignmentActuator(gameObject);
		_m_sphericalsensor = new AKN_SphericalSensor(gameObject, _Dov);
	}
    new public void Start()
    {
        
    }
 /*  public void OnDrawGizmos()
    {
            Gizmos.color = Color.red;
            directionR = transform.TransformDirection(Vector3.forward) * 2;
            Gizmos.DrawRay(transform.position, directionR);
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, _Dov);

          /*  Gizmos.color = Color.black;
            if (m_actuator != null)
            {
                ((AKN_AlignmentActuator)m_actuator).MDraw();
            }
    }*/
    new public void Update()
    {
        if (_m_sphericalsensor.MUpdate())
        {
            ((AKN_AlignmentActuator)m_actuator).MSetNeighbors(_m_sphericalsensor.m_output);
            ((AKN_AlignmentActuator)m_actuator).MUpdate();
            /*m_force = ((AKN_AlignmentActuator)m_actuator).m_force;
            if (m_force != Vector3.zero)
            {
                 m_force = m_force.normalized * m_velocity;
                 Quaternion rotation = Quaternion.LookRotation(new Vector3(m_force.x, 0, m_force.z), Vector3.up);
                 transform.rotation = rotation;
                 gameObject.transform.Translate(m_force.x * Time.deltaTime, 0, m_force.z * Time.deltaTime, Space.World);
       
            }*/
        }
    }
}