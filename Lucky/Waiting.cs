using UnityEngine;
using System.Collections;

public class Waiting : MonoBehaviour {

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
            _m_lucky.m_Waiting = true;
            _m_lucky.m_Falling = false;
            _m_lucky.m_Resisting = false;

        }
    }

    void Update()
    {

    }
}
