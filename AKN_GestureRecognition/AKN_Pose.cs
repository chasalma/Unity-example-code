using UnityEngine;
using System.Collections.Generic;
namespace AKeNe.AI.GestureRecognition
{
    public class AKN_Pose
    {
		//FIXME : range ta chambre !
		// Mettre les déclarations en premier puis les fonctions.
		// cleaner le script, rempli de code poubelle.
		public class _AKN_Pose_Data
		{
			public float m_x;
			public float m_y;
			public float m_z;
			public _AKN_Pose_Data( GameObject _go)
			{ // constructeur
				m_x = _go.transform.localPosition.x;
				m_y = _go.transform.localPosition.y;
				m_z = _go.transform.localPosition.z;
			}
		}

        private SortedDictionary<string,_AKN_Pose_Data> _m_gameObjectList; // creates an already sorted dictionary of PoseData
        public 	SortedDictionary<string,_AKN_Pose_Data> m_gameObjectList
        {
            get
            {
                return _m_gameObjectList;
            }
        }

        public AKN_Pose()
        { // constructeur
            _m_gameObjectList = new SortedDictionary<string,_AKN_Pose_Data>();
        }

        public AKN_Pose(params GameObject[] _go) : this()
        {
           // _m_skeletonComponenet = _skeletonComponenet;
           
            //_m_file.MNewComment("File Name is " + _m_NameFile + " , Pause Name " + _m_TypeOfPose);
            //_m_SekeletonJoints = new AKN_SkeletonJoints(_skeletonComponenet);
            //foreach (KeyValuePair<string, GameObject> kvp in _m_SekeletonJoints.m_Joints)
            for (int i = 0; i < _go.Length; i++)
            {
                _m_gameObjectList[_go[i].name]=new _AKN_Pose_Data(_go[i]);
            }
           
        }
    
        public AKN_Pose(List<GameObject>_go)   : this()
        {
			foreach(GameObject current in _go)
            {
                _m_gameObjectList[current.name]=new _AKN_Pose_Data(current);
            }  
        }

        public akn_pose(list<gameobject> _go)
        {
            foreach (gameobject current in _go)
            {
                _m_pose[current.name] = current;
            }
        }


    }
}

