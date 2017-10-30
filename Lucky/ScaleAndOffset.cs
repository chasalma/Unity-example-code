using UnityEngine;
using System.Collections;

public class ScaleAndOffset : MonoBehaviour {

    private Vector3 m_positionOffset;
    public Transform m_position;
    public float m_scale;

	// Use this for initialization
	void Start () {
        m_positionOffset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = m_positionOffset + m_position.position * m_scale;
	}
}
