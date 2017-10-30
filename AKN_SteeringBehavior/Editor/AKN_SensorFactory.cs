using UnityEngine;
using UnityEditor;
using System.Collections;

namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_SensorFactory
    {

        [MenuItem("AKeNe/AI/Steering Behavior/Sensor/Amer")]
        static void MCreateAmerSensor()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_AmerSensor_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Sensors.Add(obj.GetComponent<AKN_AmerSensor_Component>());
                obj.GetComponent<AKN_AmerSensor_Component>().enabled = false;
            }
        }

        [MenuItem("AKeNe/AI/Steering Behavior/Sensor/Collision")]
        static void MCreateCollisionSensor()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_CollisionSensor_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Sensors.Add(obj.GetComponent<AKN_CollisionSensor_Component>());
                obj.GetComponent<AKN_CollisionSensor_Component>().enabled = false;
            }
        }

        [MenuItem("AKeNe/AI/Steering Behavior/Sensor/Smart Terrain")]
        static void MCreateSmartTerrainSensor()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_SmartTerrainSensor_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Sensors.Add(obj.GetComponent<AKN_SmartTerrainSensor_Component>());
                obj.GetComponent<AKN_SmartTerrainSensor_Component>().enabled = false;
            }
        }

        [MenuItem("AKeNe/AI/Steering Behavior/Sensor/Spherical")]
        static void MCreateSphericalSensor()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_SphericalSensor_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Sensors.Add(obj.GetComponent<AKN_SphericalSensor_Component>());
                obj.GetComponent<AKN_SphericalSensor_Component>().enabled = false;
            }
        }

        [MenuItem("AKeNe/AI/Steering Behavior/Sensor/View")]
        static void MCreateViewSensor()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_ViewSensor_Component>();
            AKN_SAN_Component _m_San = obj.GetComponent<AKN_SAN_Component>();
            if (_m_San != null)
            {
                _m_San.m_Sensors.Add(obj.GetComponent<AKN_ViewSensor_Component>());
                obj.GetComponent<AKN_ViewSensor_Component>().enabled = false;
            }
        }

    }
}
