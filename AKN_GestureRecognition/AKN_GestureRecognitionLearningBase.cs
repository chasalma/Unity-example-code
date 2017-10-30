using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AKeNe.AI.GestureRecognition
{
	public class AKN_GestureRecognitionLearningBase
	{
		//creates a list of gestures and add new gestures to the list
        List<AKN_Gesture> _m_gestureList;
        string _m_gestureName;

        public string m_name
        {
            get
            {
                return _m_gestureName;
            }
        }

        public List<AKN_Gesture> m_gestureList
        {
            get
            {
                return _m_gestureList;
            }
        }

        public AKN_GestureRecognitionLearningBase():this(AKN_Gesture.UNKNOWN,new List<AKN_Gesture>())
        {

        }

        public AKN_GestureRecognitionLearningBase(string _name, List<AKN_Gesture> _gesture)
        { //registers new gesture and its name
            _m_gestureList = _gesture;
            _m_gestureName = _name;
        }

        public AKN_GestureRecognitionLearningBase(string _name, AKN_Gesture _gesture)
        { // add the gesture to the list
            _m_gestureList = new List<AKN_Gesture>();
            _m_gestureList.Add( _gesture);
            _m_gestureName = _name;
        }
    }
}
