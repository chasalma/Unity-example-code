using UnityEngine;
using System.Collections;

public class HeadRotationCtrl : MonoBehaviour {
	
	public float m_speed = 100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.up,m_speed*Time.deltaTime);	
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.up,-m_speed*Time.deltaTime);	
		}
	}
}
