using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;
public class AKN_SAN_Boids_Component : MonoBehaviour {


    private AKN_CohesionActuator _m_cohesion;
    private AKN_AlignmentActuator _m_alignment;
    private AKN_SeparationActuator _m_separation;
    private AKN_SphericalSensor _m_spherical;
    private AKN_FleeActuator _m_Flee;
    private AKN_ViewSensor _m_view;
    private AKN_SAN _m_San;
    private AKN_FleeActuator _m_Flee_FromEnnemie;
    private AKN_ObstacleAvoidanceActuator _m_obstacleAvoidance;

    public float m_dov = 7f;
    public float m_velocity = 4f;
    public float m_aov = 45f;
    public float m_radius = 3f;
    public float m_CoefALign = 0.8f;
    public float m_CoefSep = 0.31f;
    public float m_CoefCohes = 0.32f;
    public float m_CoefFlee = 0.4f;
    public float m_CoefFleeEnnemie = 1f;
    public GameObject m_Ennemie;

    public void Start()
    {
        _m_San = new AKN_SAN(gameObject);
        _m_spherical = new AKN_SphericalSensor(gameObject, m_dov);
        _m_cohesion = new AKN_CohesionActuator(gameObject);
        _m_alignment = new AKN_AlignmentActuator(gameObject);
        _m_separation = new AKN_SeparationActuator(gameObject);
        _m_view = new AKN_ViewSensor(gameObject, m_aov, m_dov);
        _m_Flee = new AKN_FleeActuator(gameObject, m_radius);
        _m_Flee_FromEnnemie = new AKN_FleeActuator(gameObject, m_radius);
        _m_obstacleAvoidance = new AKN_ObstacleAvoidanceActuator(gameObject, m_radius);

        _m_San.MAddSAPair(_m_spherical, _m_alignment, m_CoefALign);
        _m_San.MAddSAPair(_m_spherical, _m_separation, m_CoefCohes);
        _m_San.MAddSAPair(_m_spherical, _m_cohesion, m_CoefSep);

    }


     public void OnDrawGizmos()
     {
         Gizmos.color = Color.red;
         Vector3   directionR = transform.TransformDirection(Vector3.forward) * 2;
         Gizmos.DrawRay(transform.position, directionR);
        /*
         Gizmos.color = Color.white;
         Gizmos.DrawWireSphere(transform.position, m_dov);
         
         */
     }

    public void Update()
    {
        Vector3 m_force = Vector3.zero;
        int i = 0;

        _m_Flee_FromEnnemie.m_EnnemiePosition = m_Ennemie.transform.position;
        _m_Flee_FromEnnemie.MUpdate();

        _m_obstacleAvoidance.MUpdate();
         _m_view.MUpdate();
        if (_m_San.MUpdate())
        {
            foreach (GameObject go in _m_view.m_output)
            {
                _m_Flee.m_EnnemiePosition = go.transform.position;
                _m_Flee.MUpdate();
                m_force = m_force + (_m_Flee.m_force * m_CoefFlee);
               
                i++;
            }
            if (i > 0)
            {
                i = 1 / i;
                m_force = m_force * i;
                m_force += _m_San.m_AverageForce + _m_Flee_FromEnnemie.m_force;
                m_force = m_force * 0.33f;
            }
            else
            {
                m_force = (m_force + _m_San.m_AverageForce + _m_Flee_FromEnnemie.m_force + _m_obstacleAvoidance.m_force) * 0.33f; 
            }
            m_force = m_force.normalized * m_velocity;
            Quaternion rotation = Quaternion.LookRotation(new Vector3(m_force.x, 0, m_force.z), Vector3.up);
            transform.rotation = rotation;
            gameObject.transform.Translate(m_force.x * Time.deltaTime, 0, m_force.z * Time.deltaTime, Space.World);
       
        }
    }
}
