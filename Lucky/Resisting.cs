using UnityEngine;
using System.Collections;

public class Resisting : MonoBehaviour {

    private LukyBehavior _m_lucky;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LukyBehavior>() != null)
        {
            _m_lucky = other.GetComponent<LukyBehavior>();
            _m_lucky.m_Waiting = false;
            _m_lucky.m_Falling = false;
            _m_lucky.m_Resisting = true;

        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
