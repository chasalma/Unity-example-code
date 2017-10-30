using UnityEngine;
using System.Collections;

public class GetAway : MonoBehaviour {

    
	// Use this for initialization
    private Animator m_animator;
    private SpeechControler m_SpeechControler;
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_SpeechControler = GetComponent<SpeechControler>();
    }
    void OnTriggerEnter(Collider other)  
    {
      //  Debug.Log("on trigger enter");
        if (other.name == "Pozzo")
        {
            Debug.Log("je vois pozzo");
            if (m_animator != null)
            {
                m_animator.SetBool("Idle", false);
                m_animator.SetBool("Walk", false);
                m_animator.SetBool("Back", true);
                m_animator.SetBool("Turn", false);
                m_animator.SetBool("TurnRight", false);
                m_animator.SetBool("TurnLeft", false);
            }
        }
       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
