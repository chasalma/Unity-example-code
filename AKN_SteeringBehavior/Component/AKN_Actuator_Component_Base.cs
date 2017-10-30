using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public abstract class AKN_Actuator_Component_Base : MonoBehaviour {

    public AKN_Actuator m_actuator;
    public GameObject m_goal;
	// Use this for initialization
    public void Start()
    {
	
	}
	
	// Update is called once per frame
    public void Update()
    {
        m_actuator.MUpdate();
	}
}
