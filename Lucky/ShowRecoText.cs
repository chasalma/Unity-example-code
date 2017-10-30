using UnityEngine;
using System.Collections;

public class ShowRecoText : MonoBehaviour {
	AKN_SpeechRecoComponent m_component;
	// Use this for initialization
	void Start () {
		m_component =  GetComponent<AKN_SpeechRecoComponent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.V))
			m_component.m_showLog = !m_component.m_showLog;
	}
}
