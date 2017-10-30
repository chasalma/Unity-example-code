using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior ;
public class AKN_SeekActuator_Component : AKN_VelocityActuator_Component
{
    
    public float m_radius = 4f;
    // Use this for initialization
	 public void Awake() {
		  m_actuator  = new AKN_SeekActuator(gameObject, m_goal.transform.position, m_radius);
	}
     new public void Start()
    {
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (m_actuator != null)
            ((AKN_SeekActuator)m_actuator).MDraw();
    }
    
    // Update is called once per frame
    new public void Update()
    {
        if (!((AKN_SeekActuator)m_actuator).MUpdate())
        {
            m_force = ((AKN_SeekActuator)m_actuator).m_force;
            m_force = m_force.normalized * m_velocity;

           Quaternion rotation = Quaternion.LookRotation(new Vector3(m_force.x, 0, m_force.z), Vector3.up);
            transform.rotation = rotation;
            gameObject.transform.Translate(m_force.x * Time.deltaTime, 0, m_force.z * Time.deltaTime, Space.World);
        }
        else
        {
            Vector2 rand = Random.insideUnitCircle * 10f;
            ((AKN_SeekActuator)m_actuator).m_goal = new Vector3(rand.x, 0f, rand.y);
        }

    }
}

