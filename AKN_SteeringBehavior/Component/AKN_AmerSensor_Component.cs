using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_AmerSensor_Component : AKN_Sensor_Component_Base
{
    
    public string m_name = "Hunger";
    public string m_message = "I'm hungry !!";
    public float m_maxValue = 10f;
    public float m_minValue = 1f;
    public float m_speed = 2f;

    public void Awake()
    {
		
		m_Sensor = new AKN_AmerSensor(m_name, m_maxValue, m_minValue, m_speed, gameObject, m_message);

	}
    new public void Start()
    {
    }

    // Update is called once per frame
    new public void Update()
    {
        m_Sensor.MUpdate();
    }
}
