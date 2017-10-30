using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_ArriveActuator_Component : AKN_VelocityActuator_Component
{
    public float m_Radius=4;
    public float m_Damping  = 2;  
    public float m_maxForce= 10;
    // Use this for initialization
    public void Awake()
    {
        m_actuator = new AKN_ArriveActuator(gameObject, m_goal.transform.position);
    }
    new public void Start()
    {
           ((AKN_ArriveActuator)m_actuator).m_arriveRadius = m_Radius ;
           ((AKN_ArriveActuator)m_actuator).m_arriveDamping = m_Damping ;
           ((AKN_ArriveActuator)m_actuator).m_maxForce = m_maxForce;
    }
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.black;
    //    if (m_actuator != null)
    //    {
    //        m_actuator.MDraw();
    //    }
    //}
    // Update is called once per frame
    new public void Update()
    {
        ((AKN_ArriveActuator)m_actuator).MUpdate();
        m_force = ((AKN_ArriveActuator)m_actuator).m_force;
        m_force = m_force.normalized * m_velocity;
       /* Quaternion rotation = Quaternion.LookRotation(new Vector3(m_force.x, 0, m_force.z), Vector3.up);
        transform.rotation = rotation;
        gameObject.transform.Translate(m_force.x * Time.deltaTime, 0, m_force.z * Time.deltaTime, Space.World);*/
    }

}