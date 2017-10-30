using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;

    public class AKN_VelocityActuator_Component : AKN_Actuator_Component_Base
    {
        public float m_velocity = 4f;
        public Vector3 m_force;
        public float _Dov = 7f;
        // Use this for initialization
        new public void Start()
        {
        }

        // Update is called once per frame
        new public  void Update()
        {
        }
    }