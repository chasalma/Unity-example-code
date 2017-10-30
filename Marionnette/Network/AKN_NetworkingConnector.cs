using UnityEngine;
using System.Collections;

public class AKN_NetworkingConnector : MonoBehaviour
{
    public string m_connectionIP = "192.1.159.29";//"127.0.0.1";
    public int m_connectionPort = 25001;
    public GameObject m_AR ;
   
    void OnGUI()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            m_connectionIP = GUI.TextField(new Rect(10, 10, 200, 20), m_connectionIP, 25); 
            GUI.Label(new Rect(10, 40, 300, 20), "Status: Disconnected");
            if (GUI.Button(new Rect(10, 60, 220, 50), "Client Connect"))
            {
                Network.Connect(m_connectionIP, m_connectionPort);
            }
            if (GUI.Button(new Rect(10, 120, 220, 50), "Initialize Server"))
            {
                Network.InitializeServer(32, m_connectionPort, false);
            }
        }
        else if (Network.peerType == NetworkPeerType.Client)
        {
            GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Client");
            
            if (GUI.Button(new Rect(10, 30, 220, 50), "Disconnect"))
            {
                Network.Disconnect(200);
            }
        }
        else if (Network.peerType == NetworkPeerType.Server)
        {
            GUI.Label(new Rect(10, 10, 300, 20), "Status: Connected as Server");
            if (GUI.Button(new Rect(10, 30, 220, 50), "Disconnect"))
            {
                Network.Disconnect(200);
            }
        }
    }
}

