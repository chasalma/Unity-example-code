using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_ObstacleAvoidanceActuator_Component : AKN_VelocityActuator_Component {

    private AKN_SeekActuator m_seek;

    public float m_radiusAvoidance = 0.3f;
    public float m_radius = 4f;
    public float coefSeek = 0.6f;
    public float coefAvoidance = 0.5f;
  
	 public void Awake()
    {
            m_actuator = new AKN_ObstacleAvoidanceActuator(gameObject, m_radiusAvoidance);//, "world");
          
    }
     new void Start()
     {
        m_seek = new AKN_SeekActuator(gameObject, m_goal.transform.position, m_radius);
	}
  /*  public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 2;
        Gizmos.DrawRay(transform.position, direction);
        Gizmos.color = Color.yellow;
        if (m_actuator != null)
        {
            m_actuator.MDraw();
        }

    }*/

	// Update is called once per frame
     new void Update()
     {

         m_force = Vector3.zero;

           ((AKN_ObstacleAvoidanceActuator)m_actuator).MUpdate();
           m_force = ((AKN_ObstacleAvoidanceActuator)m_actuator).m_force ;

           if (!m_seek.MUpdate())
           {
               m_force += (m_seek.m_force * coefSeek);
               if (m_force.sqrMagnitude > (m_velocity * m_velocity))
               {
                   m_force = m_force.normalized * m_velocity;
               }
           }
           else
           {
               Vector2 rand = Random.insideUnitCircle * 10f;
               m_seek.m_goal = new Vector3(rand.x, 0f, rand.y);
           }

          /* Quaternion rotation = Quaternion.LookRotation(new Vector3(m_force.x, 0, m_force.z), Vector3.up);
           transform.rotation = rotation;
           gameObject.transform.Translate(m_force.x * Time.deltaTime, 0, m_force.z * Time.deltaTime, Space.World);*/
    }
}
