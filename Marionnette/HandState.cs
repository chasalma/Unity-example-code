using UnityEngine;
using System.Collections;

public class HandState : MonoBehaviour {

     GameObject _m_Index;
     GameObject _m_middel;
     GameObject _m_pinky;
     GameObject _m_ring;
     GameObject _m_thumb;
     public bool m_HandClosed = false;
    Vector3 _m_Distance;
	// Use this for initialization
	void Start () {
        _m_Index = transform.GetChild(1).gameObject;
        _m_middel = transform.GetChild(2).gameObject;
        _m_pinky = transform.GetChild(3).gameObject;
        _m_ring = transform.GetChild(4).gameObject;
        _m_thumb = transform.GetChild(5).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    _m_Distance = _m_middel.transform.position -_m_thumb.transform.position ;
       // Debug.Log ("distance between middel and thumb" + (_m_middel.transform.position -_m_thumb.transform.position));

        if (_m_Distance.x > -5 && _m_Distance.y < 5)
        {   
            Debug.Log("Hand closed");
            m_HandClosed = true;
        }
        else
        {
            Debug.Log("Hand Opened");
            m_HandClosed = false;
        }
	}
}
