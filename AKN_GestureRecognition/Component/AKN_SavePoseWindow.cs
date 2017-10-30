using UnityEngine;
using System.Collections;

public class AKN_SavePoseWindow : MonoBehaviour
{


    private bool _m_save;
    private bool _m_cancel;
    private bool _m_snapshot;
    private bool _m_close;

    private Rect _m_window = new Rect(20, 20, 500, 400);
    private Rect _m_windowPoseForSave = new Rect(20, 20, 300, 200);
    private Rect _m_WindowPlay = new Rect(25, 25, 300, 200);

    void OnGUI()
    {
        _m_window = GUI.Window(0, _m_window, WindowPose, "KINECT");
        if (_m_snapshot)
        {
            _m_windowPoseForSave = GUI.Window(0, _m_windowPoseForSave, WindowPoseForSave, "Pose KINECT");
        }

    }
    void WindowPose(int windowID)
    {
        //_m_WindowPlay = GUI.Window(1 , new Rect(10, 20, 350, 300), WindowPlay, "ici affichage skeleton en live");
        GUI.TextArea(new Rect(10, 20, 350, 300), "ici affichage skeleton en live");
        _m_snapshot = GUI.Button(new Rect(370, 20, 80, 20), "Snapshot");
        _m_close = GUI.Button(new Rect(370, 50, 80, 20), "Close");
        //  _m_WindowPlay = GUI.Window(0, _m_WindowPlay, WindowPlay, "Skeleton");


    }
    void WindowPoseForSave(int windowID)
    {
        _m_save = GUI.Button(new Rect(220, 30, 80, 20), "Save");
        _m_cancel = GUI.Button(new Rect(220, 30, 80, 20), "Cancel");
    }
    void WindowPlay(int windowID)
    {

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
