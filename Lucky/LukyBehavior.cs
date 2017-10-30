using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class LukyBehavior : MonoBehaviour 
{

    public GameObject m_Goal;
    public GameObject m_Controlleur;
    public GameObject m_FalconPosition;
    public float m_DesiredVelocity = 0.1f;
    public bool m_Falling = false ;
    public bool m_Waiting = false;
    public bool m_Resisting = false;

    private Animator _m_Animator;
    private NavMeshAgent _m_NavMeshAgent;
    private float _m_Velocity = 0f;


    private Vector3 _m_PreviousPosition;
    private Vector3 _m_CurrentPosition;

    //public void CalculateVelocity()
    //{
    //    yield return new WaitForSeconds(1);
    //    _m_CurrentPosition = transform.position;
    //    _m_Velocity = (_m_CurrentPosition - _m_PreviousPosition).sqrMagnitude;
    //    Debug.Log("Vitesse = " + _m_Velocity);
    //}

	// Use this for initialization
	void Start () {

        _m_Animator = GetComponent<Animator>();
        _m_NavMeshAgent = GetComponent<NavMeshAgent>();
        _m_PreviousPosition = transform.position;
	}

   
	// Update is called once per frame
	void Update () {
        //_m_CurrentPosition = transform.position;
        //_m_Velocity = (_m_CurrentPosition - _m_PreviousPosition).sqrMagnitude;
        //Debug.Log("Vitesse = " + _m_Velocity);
        //_m_PreviousPosition = transform.position;
        //if (_m_Velocity == 0)
        //{
        //    m_Waiting = true;
        //}
        //else
        //{
        //    if (_m_Velocity > m_DesiredVelocity)
        //    {
        //        m_Falling = true;
        //    }
        //    else
        //    {
        //        m_Resisting = true;
        //    }
        //}
       

        if (m_Waiting)
        {
            _m_Animator.SetBool("Falling", false);
            _m_Animator.SetBool("Resisting", false);
            _m_Animator.SetBool("Waiting", true);
            _m_NavMeshAgent.enabled = false;
           
           
        }
        else
        {
            if (m_Resisting)
            {
                _m_Animator.SetBool("Falling", false);
                _m_Animator.SetBool("Waiting", false);
                _m_Animator.SetBool("Resisting", true);
                _m_NavMeshAgent.enabled = true;
                _m_NavMeshAgent.SetDestination(m_Goal.transform.position);
                m_Controlleur.transform.Translate(0, 0, -1, Space.World);
                //deplacer la capsule aussi 
            }
            else
            {
                if (m_Falling)
                {
                    _m_Animator.SetBool("Resisting", false);
                    _m_Animator.SetBool("Waiting", false);
                    _m_Animator.SetBool("Falling", true);
                    _m_NavMeshAgent.enabled = false;
                 
                }
                else
                {
                    Debug.Log("Pas de comportement");
                }
            }
        }

	}
}
