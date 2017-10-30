using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class SpeechControler : MonoBehaviour {
    public string m_newSentence = "";
    public AKN_SpeechRecoComponent m_component;
    public bool m_RopeStop = false ;
    public GameObject m_Pazzo;
	public GameObject m_Arbre ;
    public float m_DistanceMin = 3f;
    //public float m_DistanceMax = 4f;

	private Animator m_animator;
    private NavMeshAgent _m_NavMeshAgent;
	void Start () 
    {
		m_animator = GetComponent<Animator>();
        _m_NavMeshAgent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {

        float distance = (transform.position - m_Pazzo.transform.position).sqrMagnitude;
       
        if (!m_RopeStop)
        {
            if (m_newSentence != m_component.m_detectedSentence)
            {
                m_newSentence = m_component.m_detectedSentence;
                m_animator.SetBool("Idle", false);
                m_animator.SetBool("Walk", false);
                m_animator.SetBool("Back", false);
                m_animator.SetBool("Turn", false);
                m_animator.SetBool("TurnRight", false);
                m_animator.SetBool("TurnLeft", false);
                m_animator.SetBool("GetUp", false);
                if (distance < m_DistanceMin)
                {
                   _m_NavMeshAgent.enabled = false;
					m_animator.SetBool("Back", true);
                }
                else
                {
                    //if (distance < m_DistanceMax)
                    //{
                        switch (m_newSentence)
                        {
                            case "AVANCE":
								_m_NavMeshAgent.enabled = true;
								_m_NavMeshAgent.SetDestination(transform.forward*1000f + transform.position);

                                m_animator.SetBool("Walk", true);
                                // transform.LookAt(-m_Pazzo.transform.forward);
                                break;
                            case "STOP":
							 	_m_NavMeshAgent.enabled = false;
                                m_animator.SetBool("Idle", true);
                                break;
                            case "ATTEND":
                                _m_NavMeshAgent.enabled = false;
								m_animator.SetBool("Idle", true);
                                break;
                            case "VIENT":
								 _m_NavMeshAgent.enabled = true;
                                _m_NavMeshAgent.SetDestination(m_Pazzo.transform.position);
                                m_animator.SetBool("Walk", true);
                                break;
							case "ARBRE":
								_m_NavMeshAgent.enabled = true;
                                _m_NavMeshAgent.SetDestination(m_Arbre.transform.position);
                                m_animator.SetBool("Walk", true);
                                break;
                            case "RECULE":
								_m_NavMeshAgent.enabled = false;

                                m_animator.SetBool("Back", true);
                                break;
                            case "ARRIERE":
                                m_animator.SetBool("Back", true);
								_m_NavMeshAgent.enabled = false;
                                break;
                            case "TOURNE":
                                m_animator.SetBool("Turn", true);
								_m_NavMeshAgent.enabled = false;

                                break;
                            case "TOURNE A DROITE":
                                m_animator.SetBool("TurnRight", true);
								_m_NavMeshAgent.enabled = false;

                                break;
                            case "TOURNE A GAUCHE":
                                m_animator.SetBool("TurnLeft", true);
								_m_NavMeshAgent.enabled = false;

                                break;
                            case "LEVE TOI":
                                m_animator.SetBool("GetUp", true);
								_m_NavMeshAgent.enabled = false;
						
                                break;
                            case "DEBOUT":
                                m_animator.SetBool("GetUp", true);
								_m_NavMeshAgent.enabled = false;

                                break;
                            default:
                                m_animator.SetBool("Idle", true);
                                break;
                        }
                    //}
                    //else
                    //{
                    //    m_animator.SetBool("Idle", true);
                    //}
                }
            }
        }
        else
        {

            m_animator.SetBool("Walk", false);
            m_animator.SetBool("Back", false);
            m_animator.SetBool("Turn", false);
            m_animator.SetBool("TurnRight", false);
            m_animator.SetBool("TurnLeft", false);
            m_animator.SetBool("Idle", true);
            m_animator.SetBool("GetUp", false);
        }
	
	}
}
