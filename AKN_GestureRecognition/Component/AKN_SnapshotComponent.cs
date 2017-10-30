using UnityEngine;
using System.Collections;
using AKeNe.AI.AKN_GestureRecognition;
using AKeNe.Device.Kinect;
public class AKN_SnapshotComponent : MonoBehaviour
{

    public GameObject m_Kinect;
    private bool _m_snapshot;
    private bool _m_close;
    private string _m_nameFile = "FileName";
    private string _m_Namefile = "File Name :";

    private string _m_TypeOFPose = "";
    private string _m_TypeofPose = "Type :";

    private string _m_ValueOFPose = "";
    private string _m_ValueofPose = "Value :";

    private AKN_Pose _m_pose;
    private AKN_SaveGameObjectXML _m_file;
    public AKN_KinectComponent m_KinectComponent;
    private Rect _m_window = new Rect(5, 5, 200, 200);

    void OnGUI()
    {
        _m_window = GUI.Window(0, _m_window, WindowPose, "KINECT");

    }
    void WindowPose(int windowID)
    {
        GUI.Label(new Rect(10, 25, 80, 20), _m_Namefile);
        _m_nameFile = GUI.TextArea(new Rect(90, 25, 80, 20), _m_nameFile);

        GUI.Label(new Rect(10, 60, 80, 20), _m_TypeofPose);
        _m_TypeOFPose = GUI.TextArea(new Rect(90, 60, 80, 20), _m_TypeOFPose);
        _m_snapshot = GUI.Button(new Rect(10, 95, 80, 20), "Snapshot");

        /* GUI.Label(new Rect(10, 95, 80, 20), _m_ValueofPose);
         _m_ValueOFPose = GUI.TextArea(new Rect(90, 95, 80, 20), _m_ValueOFPose);
         _m_snapshot = GUI.Button(new Rect(10, 130, 80, 20), "Snapshot");*/

    }

    void Update()
    {

        if (_m_snapshot)
        {
            _m_pose = new AKN_Pose(_m_nameFile);
            if (m_Kinect != null)
            {
                m_KinectComponent = m_Kinect.GetComponent<AKN_KinectComponent>();
            }
            else
            {
                if (GetComponent<AKN_KinectComponent>() != null)
                {
                    m_KinectComponent = GetComponent<AKN_KinectComponent>();
                }
                else
                {
                    Debug.Log("Error in Kinect Component");
                }
            }


            m_kenectskeletoncomponent = GetComponent<AKN_KinectComponent>();

            if (m_kenectskeletoncomponent != null)
            {
                if (_m_TypeOFPose != "")
                {
                    _m_pose.MAddTypeOfPose(_m_TypeOFPose);
                    if (_m_ValueOFPose != "")
                    {
                        _m_pose.MRecord(m_kenectskeletoncomponent);
                    }
                    else
                        _m_pose.MRecord(m_kenectskeletoncomponent);
                }
                else
                    Debug.Log("Type of pose not defined");
            }
            else
                Debug.Log("Erron in recording file");

        }
    }
    void OnApplicationQuit()
    {
        _m_pose.MClose();
    }
}

            if (m_KinectComponent != null)
            {
                if (_m_TypeOFPose != "")
                {
                    _m_pose.MAddTypeOfPose(_m_TypeOFPose);
                    if (_m_ValueOFPose != "")
                    {
                        _m_pose.MRecord(m_KinectComponent);
                    }
                    else
                        _m_pose.MRecord(m_KinectComponent);
                }
                else
                    Debug.Log("Type of pose not defined");
            }
            else
                Debug.Log("Erron in recording file");
            _m_pose.MClose();
        }
    }
}
