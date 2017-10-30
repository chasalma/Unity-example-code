using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AKeNe.AI.SteeringBehavior;

public class AKN_SeparationActuator_Component : AKN_VelocityActuator_Component
{

    //private AKN_SeparationActuator _m_SeparationActuator;
    private AKN_SphericalSensor _m_sphericalsensor;
    // Use this for initialization
    public void Awake()
    {
        _m_sphericalsensor = new AKN_SphericalSensor(gameObject, _Dov);
        m_actuator = new AKN_SeparationActuator(gameObject);

    }
    new public void Start()
    {
    }
    new public void Update()
    {
        _m_sphericalsensor.MUpdate();
        ((AKN_SeparationActuator)m_actuator).MSetNeighbors(_m_sphericalsensor.m_output);
        ((AKN_SeparationActuator)m_actuator).MUpdate();
        m_force = ((AKN_SeparationActuator)m_actuator).m_force;
            m_force = m_force.normalized * m_velocity;
       /* Quaternion rotation = Quaternion.LookRotation(new Vector3(m_force.x, 0, m_force.z), Vector3.up);
        transform.rotation = rotation;
        gameObject.transform.Translate(m_force.x * Time.deltaTime, 0, m_force.z * Time.deltaTime, Space.World);*/
    }
}
