using UnityEngine;
using System.Collections;

public class activator : MonoBehaviour {
    public Behaviour m_component;
    public KeyCode m_key;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKey(m_key))
		{
			m_component.enabled =true;
		}
	}
}
