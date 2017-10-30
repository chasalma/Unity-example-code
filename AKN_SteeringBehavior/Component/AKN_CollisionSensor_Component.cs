using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_CollisionSensor_Component : AKN_Sensor_Component_Base
{
    
    new public void Start () {
        m_Sensor = new AKN_CollisionSensor(gameObject);
	}
    public void OnCollisionEnter(Collision collision)
    {
        if (m_Sensor != null)
           ((AKN_CollisionSensor)m_Sensor).MOnCollisionEnter(collision);
    }
	// Update is called once per frame
    new public void Update()
    {
	
	}
}
