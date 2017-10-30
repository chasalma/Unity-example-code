using UnityEngine;
using System.Collections;

public class Bodydeplacement : MonoBehaviour {
	public float m_speed =  100f;
	public float m_rotSpeed = 100f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Z))
		{
			transform.position = transform.position + new Vector3( Time.deltaTime*m_speed,0f,0f);		
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.position = transform.position + new Vector3( -Time.deltaTime*m_speed,0f,0f);	
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.position = transform.position + new Vector3( 0f,0f,Time.deltaTime*m_speed);	
		}
		if(Input.GetKey(KeyCode.Q))
		{
			transform.position = transform.position + new Vector3( 0f,0f,-Time.deltaTime*m_speed);	
		}
		if(Input.GetKey(KeyCode.R))
		{
			transform.position = transform.position + new Vector3( 0f,Time.deltaTime*m_speed,0f);		
		}
		if(Input.GetKey(KeyCode.F))
		{
			transform.position  = transform.position + new Vector3( 0f,-Time.deltaTime*m_speed,0f);		
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.up,m_speed*Time.deltaTime);		
		}
		if(Input.GetKey(KeyCode.E))
		{
			transform.Rotate(Vector3.up,-m_speed*Time.deltaTime);	
		}
	}
}
