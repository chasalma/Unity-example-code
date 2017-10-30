using UnityEngine;
using System.Collections;

public class Falcon_Kinect : MonoBehaviour {
	public float m_distRope = 10f;
	public Transform m_Hand;
	public Transform m_neck;
	public Transform m_FalconVirtual;
	public Transform m_FalconReal;
	public Transform m_HandParent;
	

	public float m_fall = 1f;
	
	public float m_fallof = 0.001f;
	private Vector3 m_OldHand;
	private Vector3 m_OldNeck;
	private Vector3 m_OldRealFalcon;
	
	
	Vector3 _m_hand2Neck; 
	
	public bool m_shock;
	
	
	public Animator m_Lucky;
	// Use this for initialization
	void Start () {
	
		m_Hand.parent = m_HandParent;
		
		m_Hand.localPosition = Vector3.zero;
	}
	
	void OnDrawGizmos()	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(m_Hand.position,m_neck.position);
		
		Gizmos.DrawLine(m_FalconVirtual.position,(m_FalconVirtual.position + _m_hand2Neck.normalized) );

		Gizmos.color = Color.white;
		Gizmos.DrawLine(m_neck.position+Vector3.right,(m_neck.position + _m_hand2Neck.normalized * m_distRope+ Vector3.right) );
		
		if(m_shock){
			Gizmos.color = Color.red;	
			Gizmos.DrawSphere(m_neck.position,0.5f);
			Gizmos.DrawSphere(m_Hand.position,0.5f);
		}
		
	}
	// Update is called once per frame
	void Update () {
		_m_hand2Neck = m_Hand.position - m_neck.position;
		m_shock = (_m_hand2Neck.magnitude > m_distRope);
				Vector3 force = m_FalconReal.position - m_OldRealFalcon;
		if(m_shock)
		{
			Vector3 buffer= _m_hand2Neck;
			if(buffer.z > 0)
				buffer *= -1;
			m_FalconVirtual.position += (buffer*Time.deltaTime);
			
			if(force.magnitude > (m_fallof) )
		{
			NavMeshAgent navAgent = m_Lucky.gameObject.GetComponent<NavMeshAgent>();
			navAgent.enabled = false;
			
			if(force.magnitude < (m_fall) )
			{
				Quaternion angle = Quaternion.FromToRotation(m_Lucky.transform.forward,force);
				if(angle.eulerAngles.y > 0f)
				{
					if(angle.eulerAngles.y < 45f)
					{
						m_Lucky.SetBool("FallD45F3",true);
					}else 
					if(angle.eulerAngles.y < 90f){
						m_Lucky.SetBool("FallD90F3",true);
					
					}
					else
					if(angle.eulerAngles.y < 135f)
					{
						m_Lucky.SetBool("FallD135F4",true);
					}
					else
					if(angle.eulerAngles.y < 180f)
					{
						m_Lucky.SetBool("FallD180F4",true);
					}
				}
				else{
					if(angle.eulerAngles.y > -45f)
					{
						m_Lucky.SetBool("FallD225F3",true);
					}else 
					if(angle.eulerAngles.y > -90f){
						m_Lucky.SetBool("FallD270F3",true);
					}
					else
					if(angle.eulerAngles.y > -135f)
					{
						m_Lucky.SetBool("FallD315F3",true);
					}
					else
					if(angle.eulerAngles.y > -180f)
					{
						m_Lucky.SetBool("FallD90F4",true);
					}
				}
			
			}
			else
			{
				Quaternion angle = Quaternion.FromToRotation(m_Lucky.transform.forward,force);
				if(angle.eulerAngles.y > 0f)
				{
					if(angle.eulerAngles.y < 45f)
					{
						m_Lucky.SetBool("FallD45F4",true);
					}else 
					if(angle.eulerAngles.y < 90f){
						m_Lucky.SetBool("FallD90F5",true);
					
					}
					else
					if(angle.eulerAngles.y < 135f)
					{
						m_Lucky.SetBool("FallD135F4",true);
					}
					else
					if(angle.eulerAngles.y < 180f)
					{
						m_Lucky.SetBool("FallD180F3",true);
					}
				}
				else{
					if(angle.eulerAngles.y > -45f)
					{
						m_Lucky.SetBool("FallD225F4",true);//FallD225F4
					}else 
					if(angle.eulerAngles.y > -90f){
						m_Lucky.SetBool("FallD270F5",true);//FallD270F4
					}
					else
					if(angle.eulerAngles.y > -135f)
					{
						m_Lucky.SetBool("FallD90F4",true);
					}
					else
					if(angle.eulerAngles.y > -180f)
					{
						m_Lucky.SetBool("FallD0F4",true);
					}
				}
			}
		}else
		{
			//NavMeshAgent navAgent = m_Lucky.gameObject.GetComponent<NavMeshAgent>();
			//navAgent.enabled = true;
			m_Lucky.SetBool("FallD45F3",false);
			m_Lucky.SetBool("FallD90F3",false);
			m_Lucky.SetBool("FallD135F4",false);
			m_Lucky.SetBool("FallD180F4",false);
			m_Lucky.SetBool("FallD225F3",false);
			m_Lucky.SetBool("FallD270F3",false);
			m_Lucky.SetBool("FallD315F3",false);
			m_Lucky.SetBool("FallD90F4",false);
			m_Lucky.SetBool("FallD45F4",false);
			m_Lucky.SetBool("FallD90F5",false);
			m_Lucky.SetBool("FallD135F4",false);
			m_Lucky.SetBool("FallD180F3",false);
			m_Lucky.SetBool("FallD225F4",false);
			m_Lucky.SetBool("FallD270F5",false);
			
			m_Lucky.SetBool("FallD90F4",false);
			
			m_Lucky.SetBool("FallD0F4",false);
			
		}
		}else
		{
			m_FalconVirtual.position = Vector3.zero;
		}

		//Debug.Log(force.magnitude );
		
		m_OldRealFalcon = m_FalconReal.position; 
	}
}
				/*
				FallD90F4
				FallD-90F3
				FallD90F3
				FallD45F3
				FallD-45F3
				FallD-135F3*/