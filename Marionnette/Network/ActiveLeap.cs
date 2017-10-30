using UnityEngine;
using System.Collections;

public class ActiveLeap : MonoBehaviour {

	// Use this for initialization
    AKN_LeapHandControllerComponent _m_leapHandController ;
    void Awake()
    {
        _m_leapHandController = GetComponent<AKN_LeapHandControllerComponent>();
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Network.isServer)
        {
            _m_leapHandController.enabled = true;
        }
        else
            _m_leapHandController.enabled = false;
	}
}
