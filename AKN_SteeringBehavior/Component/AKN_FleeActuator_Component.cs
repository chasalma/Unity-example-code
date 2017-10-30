using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;

public class AKN_FleeActuator_Component : AKN_VelocityActuator_Component
{
    public float m_radius = 4f;
    public GameObject m_ennemie;

    public void Awake()
    {
        m_actuator = new AKN_FleeActuator(gameObject, m_radius, m_ennemie.transform.position);
    }
    new public void Start()
    {
    }
   public void OnDrawGizmos()
    {
        if ((AKN_FleeActuator)m_actuator != null)
            ((AKN_FleeActuator)m_actuator).MDraw();
    }

   public new void Update()
    {
        ((AKN_FleeActuator)m_actuator).m_EnnemiePosition = m_ennemie.transform.position;
        ((AKN_FleeActuator)m_actuator).MUpdate() ;
        m_force = ((AKN_FleeActuator)m_actuator).m_force;
        m_force = m_force * m_velocity;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(m_force.x, 0, m_force.z), Vector3.up);
        transform.rotation = rotation;
        gameObject.transform.Translate(m_force.x * Time.deltaTime, 0, m_force.z * Time.deltaTime, Space.World);
       
    }
}