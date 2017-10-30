using unityengine;
using system.collections;
using akene.device.kinect;
using akene.ai.akn_gesturerecognition;

public class akn_posecomponent : monobehaviour
{

    private akn_pose _m_pose;
    public string m_namepose = "skeleton";

    // use this for initialization
    void start()
    {
        _m_pose = new akn_pose(m_namepose);
        //_m_pose.m_skeletoncomponent = getcomponent<akn_kinectcomponent>();
        //_m_pose.mrecord();
    }

    // update is called once per frame
    void update()
    {

    }
}
