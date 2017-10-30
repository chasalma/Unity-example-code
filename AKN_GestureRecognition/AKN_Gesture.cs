using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AKeNe;
namespace AKeNe.AI.GestureRecognition
{
    public class AKN_Gesture
	{// create a list of new poses
        //gesture is a list of poses 
		
		#region attributes
		
        private List<AKN_Pose> _m_sample;

        public List<AKN_Pose> m_sample
        {
            get
            {
                return _m_sample;
            }
        }

        private string _m_name;

        public string m_name
        {
            get
            {
                return _m_name;
            }
        }
		#endregion

        public static string UNKNOWN = "UNKNOWN";

        public AKN_Gesture():this(UNKNOWN,new List<AKN_Pose>()){}

        public AKN_Gesture(List<AKN_Pose> _sample):this(UNKNOWN, _sample){    }

        public AKN_Gesture(string _name,List<AKN_Pose> _sample)
        {
            _m_name = _name;
            _m_sample = _sample;
        }

        public void MAddPose(AKN_Pose _pose)
        {
            _m_sample.Add(_pose);
        }
        public void MDeletePose(AKN_Pose _pose)
        {
            _m_sample.Remove(_pose);
        }
    }
}