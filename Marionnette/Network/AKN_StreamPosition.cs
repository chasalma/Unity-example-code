using UnityEngine;
using System.Collections;

public class AKN_StreamPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        if (stream.isWriting)
        {
            Vector3 pos = transform.position;
            stream.Serialize(ref pos);
        }
        else
        {
            Vector3 receivedPosition = Vector3.zero;
            stream.Serialize(ref receivedPosition);
            transform.position = receivedPosition;
        }
    }
}
