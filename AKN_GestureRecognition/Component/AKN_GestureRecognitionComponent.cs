using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using AKeNe.AI.GestureRecognition;

public class AKN_GestureRecognitionComponent : MonoBehaviour {
	//FIXME : retirer le code inutile
	// Unity specific
    
    public List<GameObject> m_input = new List<GameObject>();
    public List<float> m_output = new List<float>();

    List<AKN_GestureRecognitionLearningBase> _m_learningBase;

    AKN_GestureRecognition _m_gestureRecognition;

    public bool m_learn = false;
    public bool m_recognize = false;

   // List<AKN_GestureRecognitionLearningBase> _m_learningBaseToLearn;


    void Awake () {
        _m_gestureRecognition = new AKN_GestureRecognition(new AKN_Pose(m_input),m_output.Count);

    }

    void Start()
    {
        _m_gestureRecognition.MInitialize();
		m_output = _m_gestureRecognition.m_output;
    }
	
    void Update () {
        if (m_learn)
        {
			AKN_Pose pose = new AKN_Pose(m_input);
			
			List<AKN_Pose> listPose = new List<AKN_Pose>();
			listPose.Add(pose);
			string name = "";
			foreach( float output in m_output)
				name += output;
			AKN_Gesture gesture = new AKN_Gesture(name,listPose);
			/*AKN_GestureRecognitionLearningBase learningBase = new AKN_GestureRecognitionLearningBase(m_output.ToString(),gesture);
            _m_gestureRecognition.MAddLearningBase(learningBase);*/
			_m_gestureRecognition.MLearn(gesture);
            m_learn = false;
        }
        if (m_recognize)
        {
			
			
            _m_gestureRecognition.MRecognize(m_input);
            m_recognize = false;
        }
        m_output = _m_gestureRecognition.m_output;
    }


    public void MAddLearningBase(AKN_GestureRecognitionLearningBase _gestureLearningBase)
    {
        _m_gestureRecognition.MAddLearningBase(_gestureLearningBase);
    }

    public List<GameObject> m_input = new List<GameObject>();
    public string m_poseName = "";
    public List<float> m_output = new List<float>();
    private List<string> _m_poseNameList = new List<string>();
    public bool m_learn = false;
    public bool m_init = false;
    public bool m_think = false;
    AKN_GestureRecognition _m_gestureRecognition;
    // Use this for initialization

    void Start()
    {
        _m_gestureRecognition = new AKN_GestureRecognition();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_learn)
        {
            if (m_poseName == "")
            {
                m_poseName = "Pose" + _m_poseNameList.Count + 1;
            }
            _m_poseNameList.Add(m_poseName);

            _m_gestureRecognition.MAddPose(_m_poseNameList.Count, m_input);
            m_learn = false;
            return;
        }
        if (m_init)
        {
            _m_gestureRecognition.MInit();
            m_init = false;
            return;
        }
        if (m_think)
        {
            m_output = _m_gestureRecognition.MRecognize(m_input);
            m_think = false;
        }
    }
}
