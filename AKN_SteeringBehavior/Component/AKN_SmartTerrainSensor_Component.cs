using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_SmartTerrainSensor_Component : AKN_Sensor_Component_Base
{
    public Texture2D m_smartData;

	// Use this for initialization
    new void Start()
    {
        m_Sensor = new AKN_SmartTerrainSensor(gameObject, m_smartData);
	}
	
	// Update is called once per frame
    new void Update()
    {
        ((AKN_SmartTerrainSensor)m_Sensor).MUpdate();
	}
}
