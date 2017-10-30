using UnityEngine;
using System.Collections;
using AKeNe.AI.SteeringBehavior;

public class AKN_Boid2d_Component : MonoBehaviour {


    AKN_CohesionActuator _m_cohesion;
    AKN_AlignmentActuator _m_alignment;
    AKN_SeparationActuator _m_separation;
    AKN_SphericalSensor _m_spherical;

    public float m_dov = 10f;
    public float m_velocity = 4f;
    public float m_CoefALign = 0.5f;
    public float m_CoefSep = 0.28f;
    public float m_CoefCohes = 0.3f;
    // Use this for initialization
    void Start()
    {
        _m_spherical = new AKN_SphericalSensor(gameObject, m_dov);
        _m_cohesion = new AKN_CohesionActuator(gameObject);
        _m_alignment = new AKN_AlignmentActuator(gameObject);
        _m_separation = new AKN_SeparationActuator(gameObject);


    }
    /*  void OnDrawGizmos()
      {
          Gizmos.color = Color.red;
          Vector3  direction = transform.TransformDirection(Vector3.forward) * 2;
          Gizmos.DrawRay(transform.position, direction);
          Gizmos.color = Color.white;
          Gizmos.DrawWireSphere(transform.position, m_dov);
          Gizmos.color = Color.black;
          Gizmos.DrawLine(transform.position, _m_cohesion.m_force);
          Gizmos.color = Color.yellow;
          Gizmos.DrawLine(transform.position, _m_alignment.m_force);
          Gizmos.color = Color.green;
          Gizmos.DrawLine(transform.position, _m_separation.m_force);

      }*/

    // Update is called once per frame
    void Update()
    {

        if (_m_spherical.MUpdate())
        {
            _m_cohesion.MSetNeighbors(_m_spherical.m_output);
            _m_alignment.MSetNeighbors(_m_spherical.m_output);
            _m_separation.MSetNeighbors(_m_spherical.m_output);
            _m_separation.MUpdate();
            _m_cohesion.MUpdate();
            _m_alignment.MUpdate();
            Vector3 force = ((_m_cohesion.m_force * m_CoefCohes) + (_m_alignment.m_force * m_CoefALign) + (_m_separation.m_force * m_CoefSep)) * 0.333f;
            force = force.normalized * m_velocity;
            gameObject.transform.Translate(force.x * Time.deltaTime, 0, force.z * Time.deltaTime, Space.World);

        }


    }
}
