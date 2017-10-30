using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_ViewSensor_Component : AKN_Sensor_Component_Base
{
   
    public float m_dov = 5f;
    public float m_aov = 45f;
    public float m_radius = 1f;

	// Use this for initialization
    public void Awake()
    {
        m_Sensor = new AKN_ViewSensor(gameObject, m_aov, m_dov);
    }
    new public void Start()
    {
	}
  /*  public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, m_dov);
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * 2;
        Gizmos.DrawRay(transform.position, direction);
        //if (_m_viewSensor.MUpdate())
        //{
        //    if (_m_viewSensor.m_output.Count > 0)
        //    {
        //        Gizmos.color = Color.green;
        //        foreach (GameObject o in _m_viewSensor.m_output)
        //        {
        //            Gizmos.DrawSphere(o.transform.position, m_radius);

        //        }
        //    }
        //}
    }*/
	
	// Update is called once per frame
    new public void Update()
    {
        m_Sensor.MUpdate();
	}
}
