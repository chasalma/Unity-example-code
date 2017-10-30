using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AKeNe;
using AKeNe.AI.NeuronalNetwork;
using System;

namespace AKeNe.AI.GestureRecognition 
{

	// FIXME : delete unused code ! ; range ta chambre : les attributs ensemble ! Mieux ordonner les fonctions
    public class AKN_GestureRecognition
    {
		#region Attributes
        public AKN_Pose m_input;

        Dictionary<string,AKN_GestureRecognitionLearningBase> _m_learningBase;
		// creates an indexed tab of gestures

        List<float> _m_output;

        public List<float> m_output
        {
            get
            {
                return _m_output;
            }
        }
        Dictionary<int, string> _m_output2GestureName; // indexed tab of gesture names
        Dictionary<string,int> _m_gestureName2Output; //FIXME : le nom est très similaire à la variable juste au-dessus : comment les différencier ?

        private AKN_MultiLayerPerceptron _m_MLPerceptron; // Using AI Neuronal Network
        private AKN_Hidden_NeuronLayer _m_HiddenLayer;

        static float m_acquisitionValue = 0.8f;
		
		#endregion
		
		#region Methodes
		public AKN_GestureRecognition(AKN_Pose _input,int _output)
        {
			m_input = _input;
			_m_learningBase = new Dictionary<string,AKN_GestureRecognitionLearningBase>();
			_m_output = new List<float>();
			for(int i = 0; i < _output; i++)
			{
				_m_output.Add(0f);
			}
			_m_output2GestureName = new Dictionary<int, string>();
			_m_gestureName2Output = new Dictionary<string,int> ();
		}
		
		
        public AKN_GestureRecognition( List<AKN_GestureRecognitionLearningBase>  _learningBase)
        {
            _m_learningBase = new Dictionary<string, AKN_GestureRecognitionLearningBase>();
            foreach (AKN_GestureRecognitionLearningBase current in _learningBase)
            {
                _m_learningBase[current.m_name] = current;
            }
			_m_output2GestureName = new    Dictionary<int, string>();
			_m_gestureName2Output = new Dictionary<string,int> ();

        }

        public AKN_GestureRecognition(Dictionary<string,AKN_GestureRecognitionLearningBase> _learningBase)
        {
            _m_learningBase = _learningBase;
			_m_output2GestureName = new    Dictionary<int, string>();
			_m_gestureName2Output = new Dictionary<string,int> ();

           
        }

        public AKN_GestureRecognition(params AKN_GestureRecognitionLearningBase[] _learningBase)
        {
            for (int i = 0; i < _learningBase.Length; i++)
            {
                MAddLearningBase(_learningBase[i]);
            }
           	_m_output2GestureName = new    Dictionary<int, string>();
			_m_gestureName2Output = new Dictionary<string,int> ();

        }
		 
        public void MInitialize()
        {
            int input = MComputeNbInput();
			int output = MComputeNbOutput();
			MInitialize(input,output);

        }
		
		public void MInitialize()
        { //Start
			int input = MComputeNbInput();
			int output = _m_output.Count;
			_m_MLPerceptron = new AKN_MultiLayerPerceptron();
            _m_MLPerceptron.MAddInputNeuron(input);                     //<- Variable Magique
            _m_MLPerceptron.MAddOutputNeuron(output);
            _m_HiddenLayer = new AKN_Hidden_NeuronLayer();
            _m_MLPerceptron.MAddHiddenLayer(1);
            _m_HiddenLayer.MAddNeuron(input);
            _m_MLPerceptron.MGenerate();


            foreach (KeyValuePair<string, AKN_GestureRecognitionLearningBase> kvp in _m_learningBase)
            {
                MLearn(kvp.Value);
            }
		}
        #region MAddLearning
		public void MAddLearningBase(List<AKN_GestureRecognitionLearningBase> _learningBase)
        {
            foreach (AKN_GestureRecognitionLearningBase current in _learningBase)
            {
                MAddLearningBase(current);
            }
        }

        public void MAddLearningBase(AKN_GestureRecognitionLearningBase _learningBase)
        {

            if (_m_learningBase.ContainsKey(_learningBase.m_name))
            {
                foreach (AKN_Gesture current in _learningBase.m_gestureList)
                {
                    _m_learningBase[_learningBase.m_name].m_gestureList.Add(current);
                }
            }
            else
            {
                _m_learningBase[_learningBase.m_name] = _learningBase;
				int index = _m_output2GestureName.Keys.Count;
                _m_output2GestureName[index] = _learningBase.m_name;
                _m_gestureName2Output[_learningBase.m_name] = index;
            }
        }
		#endregion
		
		#region MLearn
        public void MLearn(AKN_GestureRecognitionLearningBase _learningBase)
        {
            //MAddLearningBase(_learningBase);
            //je montre l'exemple
            //je regarde si il a reconnu mon geste
            //si oui je sors
            //sinon je lui remontre tant qu'il ne le reconnait pas
            foreach (AKN_Gesture current in _learningBase.m_gestureList)
            {
                MLearn(current);
            }
        }


        public void MLearn(AKN_Gesture _learningBase)
        {
			if(!_m_gestureName2Output.ContainsKey(_learningBase.m_name))
			{
				AKN_GestureRecognitionLearningBase learningBase = new AKN_GestureRecognitionLearningBase(_learningBase.m_name,_learningBase);
				MAddLearningBase(learningBase);
			}
            foreach (AKN_Pose current in _learningBase.m_sample)
            {
                MLearn(_learningBase.m_name, current);
            }
        }


        public void MLearn(string _name, AKN_Pose _pose)
        {
            int recognizedGestureId = -1;

            do
            {
                
                MPerceptronLearningBase(_pose, _m_gestureName2Output[_name]);
                

                recognizedGestureId = MRecognize(_pose);

            } while (m_output[recognizedGestureId] < m_acquisitionValue ||
                   _m_output2GestureName[recognizedGestureId] != _name);

        }
		#endregion

        public void MPerceptronLearningBase(AKN_Pose _input, int _output)
        {

            AKN_Perceptron_LearningBase perceptron_LearningBase = new AKN_Perceptron_LearningBase("");

            foreach (KeyValuePair<string,AKN_Pose._AKN_Pose_Data> kvp in _input.m_gameObjectList)
            {
                perceptron_LearningBase.m_Input.Add(kvp.Value.m_x);
                perceptron_LearningBase.m_Input.Add(kvp.Value.m_y);
                perceptron_LearningBase.m_Input.Add(kvp.Value.m_z);
            }
            for (int j = 0; j < MComputeNbOutput(); j++)
             {
                 if (j == _output)
                     perceptron_LearningBase.m_Output.Add(1f);
                 else
                     perceptron_LearningBase.m_Output.Add(0f);
             }

            _m_MLPerceptron.MLearn(perceptron_LearningBase);

        }
		#region MRecognize
        public int MRecognize(AKN_Pose _pose)
        {
            int outputID = -1;
            float maxValue = float.MinValue;

            MSetInput(_pose);
            _m_MLPerceptron.MThink();
            for (int i = 0; i < _m_MLPerceptron.m_output.Count; i++)
            {
                if (maxValue < _m_MLPerceptron.m_output[i])
                {
					outputID = i;
                    maxValue = _m_MLPerceptron.m_output[i];
					
                }
                
            }

            _m_output = _m_MLPerceptron.m_output;
            return outputID;
        }
		
		public int MRecognize(List<GameObject> _pose)
        {
            int outputID = -1;
            float maxValue = float.MinValue;

            MSetInput(_pose);
            _m_MLPerceptron.MThink();
			_m_output = _m_MLPerceptron.m_output;
			
            for (int i = 0; i < _m_output.Count; i++)
            {
                if (maxValue < _m_output[i])
                {
					outputID = i;
                    maxValue = _m_output[i];
                }
                
            }

            
            return outputID;
        }
		#endregion
		
		#region MSetInput
        public void MSetInput(AKN_Pose _pose)
        {
            List<float> inputToLearn = new List<float>();
            foreach (KeyValuePair<string,AKN_Pose._AKN_Pose_Data> kvp  in _pose.m_gameObjectList)
            {
                inputToLearn.Add(kvp.Value.m_x);
                inputToLearn.Add(kvp.Value.m_y);
                inputToLearn.Add(kvp.Value.m_z);
            }
            _m_MLPerceptron.MSetInput(inputToLearn);
        }
		
		public void MSetInput(List<GameObject> _pose)
        {
         	AKN_Pose pose = new AKN_Pose(_pose);
			MSetInput(pose);
        }
		#endregion
		
		#region MComputeNb
        public int MComputeNbInput()
        {
            return m_input.m_gameObjectList.Count * 3;
        }
        public int MComputeNbOutput()
        {
            return _m_output2GestureName.Count;
        }
        #endregion
        #endregion

      
        public list<dictionary<string, gameobject>> m_pose = new list<dictionary<string, gameobject>>();
        public dictionary<string, gameobject> m_gameobject = new dictionary<string,gameobject>(); //nombre de game object pour créer une pose nombre de joint dans la kinect
     
        
        private list<float> m_output = new list<float>();
        private akn_multilayerperceptron _m_mlperceptron;
        private akn_hidden_neuronlayer _m_hiddenlayer;

        private int _m_inputnumber;
        private int _m_outputnumber;
        public int m_detectedpositionindex = -1;

        public akn_gesturerecognition(list<gameobject> _input, list<float> _output)
        {
            foreach (gameobject current in _input)
            {
                m_gameobject[current.name] = current;
            }

            for (int i = 0; i < _output.count; i++)
            {
                m_pose.add(new dictionary<string, gameobject>());
                foreach (gameobject current in _input)
                {
                    m_pose[i][current.name] = current;
                }
            }
        }

        public void maddpose(int _poseid, list<gameobject> _gameobjectpose)
        {
            while ((m_pose.count+1) <= _poseid)
            {
                dictionary<string, gameobject> buffer = new dictionary<string, gameobject>();
                foreach (gameobject current in _gameobjectpose)
                {
                    buffer[current.name] = current;
                   
                }
                m_pose.add(buffer);
                debug.log("pose added");
            }
        }

        public void minit()
        {
            _m_mlperceptron = new akn_multilayerperceptron();
            debug.log("m_gameobject.count = " + m_gameobject.count);
            _m_mlperceptron.maddinputneuron(3 * m_gameobject.count);                     //<- variable magique

            _m_mlperceptron.maddoutputneuron(m_pose.count);
            _m_hiddenlayer = new akn_hidden_neuronlayer();
            _m_mlperceptron.maddhiddenlayer(1);
            _m_hiddenlayer.maddneuron(3 * m_gameobject.count);
            _m_mlperceptron.mgenerate();
            mlearn();
            debug.log("minit");
        }
        public akn_gesturerecognition()
        {

        }
        public list<float> mrecognize(list<gameobject> _input)
        {
             dictionary<string, gameobject> buffer = new dictionary<string, gameobject>();
            foreach (gameobject current in _input)
            {
                buffer[current.name] = current;
            }
            m_gameobject = buffer;
            mthink();
            return m_output;
        }

        public void mlearn()
        {
            list<float> inputtolearn = new list<float>();
            list<float> outputtolearn = new list<float>();
            for (int i = 0; i < m_pose.count; i++)
            {
                akn_perceptron_learningbase perceptron_learningbase = new akn_perceptron_learningbase("perceptron_learningbase");

                inputtolearn.clear();
                outputtolearn.clear();
                foreach (keyvaluepair<string, gameobject> kvp in m_pose[i])
                {
                    inputtolearn.add(kvp.value.transform.localposition.x);
                    inputtolearn.add(kvp.value.transform.localposition.y);
                    inputtolearn.add(kvp.value.transform.localposition.z);
                }
                for (int j = 0; j < m_pose.count; j++)
                {
                    if (i == j)
                        outputtolearn.add(1f);
                    else
                        outputtolearn.add(0f);
                }
                perceptron_learningbase.m_input = inputtolearn;
                perceptron_learningbase.m_output = outputtolearn;
                _m_mlperceptron.mlearn(perceptron_learningbase);
            }
        }

        public void mthink()
        {
            list<float> input = new list<float>();
            foreach (keyvaluepair<string, gameobject> kvp in m_gameobject)
            {
                input.add(kvp.value.transform.localposition.x);
                input.add(kvp.value.transform.localposition.y);
                input.add(kvp.value.transform.localposition.z);
            }

            _m_mlperceptron.msetinput(input);
            _m_mlperceptron.mthink();
            m_output = _m_mlperceptron.m_output;
            float max = float.minvalue;
            int index = 0;
            for (int i = 0; i < m_output.count; i++)
            {
                if (m_output[i] > max)
                {
                    max = m_output[i];
                    index = i;
                }
            }
            m_detectedpositionindex = index;
        }

    }
}
