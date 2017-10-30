using UnityEngine;
using UnityEditor;
using System.Collections;

namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_ActuatorFactory
    {
        [MenuItem("AKeNe/AI/Steering Behavior/Actuator/Alignment")]
        static void MCreateAlignmentActuator()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_AlignmentActuator_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Actuators.Add(obj.GetComponent<AKN_AlignmentActuator_Component>());
                obj.GetComponent<AKN_AlignmentActuator_Component>().enabled = false; 
            }

        }

        [MenuItem("AKeNe/AI/Steering Behavior/Actuator/Arrive")]
        static void MCreateArriveActuator()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_ArriveActuator_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_ActuatorsOnly.Add(obj.GetComponent<AKN_ArriveActuator_Component>()); 
                obj.GetComponent<AKN_ArriveActuator_Component>().enabled = false;
            }

        }

        [MenuItem("AKeNe/AI/Steering Behavior/Actuator/Cohesion")]
        static void MCreateCohesionActuator()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_CohesionActuator_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Actuators.Add(obj.GetComponent<AKN_CohesionActuator_Component>());
                obj.GetComponent<AKN_CohesionActuator_Component>().enabled = false;
            }

        }

        [MenuItem("AKeNe/AI/Steering Behavior/Actuator/Flee")]
        static void MCreateFleeActuator()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_FleeActuator_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Actuators.Add(obj.GetComponent<AKN_FleeActuator_Component>());
                obj.GetComponent<AKN_FleeActuator_Component>().enabled = false;
            }
        }

        [MenuItem("AKeNe/AI/Steering Behavior/Actuator/Obstacle Avoidance")]
        static void MCreateObstacleAvoidanceActuator()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_ObstacleAvoidanceActuator_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_ActuatorsOnly.Add(obj.GetComponent<AKN_ObstacleAvoidanceActuator_Component>());
                obj.GetComponent<AKN_ObstacleAvoidanceActuator_Component>().enabled = false;
               
            }
        }

        [MenuItem("AKeNe/AI/Steering Behavior/Actuator/Pursuit")]
        static void MCreatePursuitActuator()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_PursuitActuator_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Actuators.Add(obj.GetComponent<AKN_PursuitActuator_Component>());
                obj.GetComponent<AKN_PursuitActuator_Component>().enabled = false;
            }
        }

        [MenuItem("AKeNe/AI/Steering Behavior/Actuator/Seek")]
        static void MCreateSeekActuator()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_SeekActuator_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
               
                _m_San.m_ActuatorsOnly.Add(obj.GetComponent<AKN_SeekActuator_Component>());
                obj.GetComponent<AKN_SeekActuator_Component>().enabled = false;
            }

        }

        [MenuItem("AKeNe/AI/Steering Behavior/Actuator/Separation")]
        static void MCreateSeparationActuator()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_SeparationActuator_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Actuators.Add(obj.GetComponent<AKN_SeparationActuator_Component>());
                obj.GetComponent<AKN_SeparationActuator_Component>().enabled = false;
            }
        }

        [MenuItem("AKeNe/AI/Steering Behavior/Actuator/NavMesh")]
        static void MCreateNavmeshActuator()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_NavMeshActuator_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_ActuatorsOnly.Add(obj.GetComponent<AKN_NavMeshActuator_Component>());
                obj.GetComponent<AKN_NavMeshActuator_Component>().enabled = false;
            }
        }
    }
}
