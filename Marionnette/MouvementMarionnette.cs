using UnityEngine;
using System.Collections;

public class MouvementMarionnette : MonoBehaviour {

    private Animator _m_Animator;
    public GameObject m_Hand;
    public GameObject m_leftHand;
    public GameObject m_imageTarget ;
   // HandState _m_HandState = new HandState();
    //public float m_Coef = 1f;
    public float m_CoefX = 1f;
    public float m_CoefY = 1f;
    public float m_CoefZ = 1f;
    private Vector3 _m_HandPos;
    GameObject _m_Index;
    GameObject _m_middel;
    GameObject _m_pinky;
    GameObject _m_ring;
    GameObject _m_thumb;
    public bool m_HandClosed = false;
    Vector3 _m_Distance;
	// Use this for initialization
	void Awake () {
        _m_Animator = GetComponent<Animator>();
       // _m_HandPos = m_Hand.transform.position;
       // _m_HandState = m_Hand.GetComponent<HandState>();
        _m_Index = m_leftHand.transform.GetChild(1).gameObject;
        _m_middel = m_leftHand.transform.GetChild(2).gameObject;
        _m_pinky = m_leftHand.transform.GetChild(3).gameObject;
        _m_ring = m_leftHand.transform.GetChild(4).gameObject;
        _m_thumb = m_leftHand.transform.GetChild(5).gameObject;
	} 
	
	// Update is called once per frame
	void Update () {
  
     //   _m_HandPos = transform.position;
      
   
      //  transform.position = new Vector3((_m_HandPos.x - m_Hand.transform.position.x )* m_CoefX , transform.position.y  , m_Hand.transform.position.z * m_CoefZ);
      ////  transform.position =  m_Hand.transform.position  * m_Coef;
       
        // Debug.Log ("distance between middel and thumb" + (_m_middel.transform.position -_m_thumb.transform.position));
        _m_Distance = _m_middel.transform.position - _m_thumb.transform.position;
        if (_m_Distance.x > -5 && _m_Distance.y < 5)
        {   
           // Debug.Log("Hand closed");
            m_HandClosed = true;
            _m_Animator.SetBool("Dance", false);
            transform.position = m_imageTarget.transform.position;
        }
        else
        {
          //  Debug.Log("Hand Opened");
            m_HandClosed = false;
            _m_Animator.SetBool("Dance", true);
            transform.position = new Vector3(transform.position.x + (-_m_HandPos.x + m_Hand.transform.position.x) * m_CoefX, transform.position.y, transform.position.z + (-_m_HandPos.z + m_Hand.transform.position.z) * m_CoefZ);
            _m_HandPos = m_Hand.transform.position;
          
        }
        
        if (m_HandClosed == true)
        {
            _m_Animator.SetBool("Dance", false);
        }
        else
        {
            _m_Animator.SetBool("Dance", true);
        }

	}
}
