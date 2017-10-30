using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_SphericalSensor_Component : AKN_Sensor_Component_Base
{
  
    public float m_Dov = 5f;
    public float m_velocity = 0.01f;
	// Use this for initialization
    public void Awake()
    {
        m_Sensor = new AKN_SphericalSensor(gameObject, m_Dov);
    }
    new public void Start()
    {
	}
   public void OnDrawGizmos()
    {
        //======> sphere en blanc
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, m_Dov);
    }
	// Update is called once per frame
    new public void Update()
    {
        m_Sensor.MUpdate();
	}
}
