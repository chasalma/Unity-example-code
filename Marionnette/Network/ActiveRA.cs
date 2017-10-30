using UnityEngine;
using System.Collections;

public class ActiveRA : MonoBehaviour {

	// Use this for initialization
    WebCamBehaviour _m_webcam;
    void Awake()
    {
        _m_webcam = GetComponent<WebCamBehaviour>();
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Network.isServer)
        {
            _m_webcam.enabled = false;
        }
        else
            _m_webcam.enabled = true;
	}
}
