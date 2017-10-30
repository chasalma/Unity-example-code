using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AKeNe.Device.Kinect;
namespace AKeNe.AI.AKN_GestureRecognition
{
    public class AKN_SkeletonJoints
    {
        public Dictionary<string, GameObject> m_Joints;

        public AKN_SkeletonJoints(AKN_KinectComponent _skeletonComponenet)
        {
            m_Joints = new Dictionary<string, GameObject>();

            m_Joints["root"] = _skeletonComponenet.m_root.gameObject;
            m_Joints["spine"] = _skeletonComponenet.m_spine.gameObject;
            m_Joints["shoulderCenter"] = _skeletonComponenet.m_shoulderCenter.gameObject;
            m_Joints["head"] = _skeletonComponenet.m_head.gameObject;

            m_Joints["shoulderLeft"] = _skeletonComponenet.m_shoulderLeft.gameObject;
            m_Joints["elbowLeft"] = _skeletonComponenet.m_elbowLeft.gameObject;
            m_Joints["wristLeft"] = _skeletonComponenet.m_wristLeft.gameObject;
            m_Joints["handLeft"] = _skeletonComponenet.m_handLeft.gameObject;

            m_Joints["shoulderRight"] = _skeletonComponenet.m_shoulderRight.gameObject;
            m_Joints["elbowRight"] = _skeletonComponenet.m_elbowRight.gameObject;
            m_Joints["wristRight"] = _skeletonComponenet.m_wristRight.gameObject;
            m_Joints["handRight"] = _skeletonComponenet.m_handRight.gameObject;

            m_Joints["hipLeft"] = _skeletonComponenet.m_hipLeft.gameObject;
            m_Joints["kneeLeft"] = _skeletonComponenet.m_kneeLeft.gameObject;
            m_Joints["ankleLeft"] = _skeletonComponenet.m_ankleLeft.gameObject;
            m_Joints["footLeft"] = _skeletonComponenet.m_footLeft.gameObject;

            m_Joints["hipRight"] = _skeletonComponenet.m_hipRight.gameObject;
            m_Joints["kneeRight"] = _skeletonComponenet.m_kneeRight.gameObject;
            m_Joints["ankleRight"] = _skeletonComponenet.m_ankleRight.gameObject;
            m_Joints["footRight"] = _skeletonComponenet.m_footRight.gameObject;

            Debug.Log("AKN_SkeletonJoints is added");

        }

    }
}