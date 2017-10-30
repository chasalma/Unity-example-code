using UnityEngine;
using UnityEditor;
using System.Collections;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_SANFactory : MonoBehaviour
    {

        [MenuItem("AKeNe/AI/Steering Behavior/SAN")]
        static void MCreateSANSensor()
        {
            GameObject obj = Selection.activeGameObject;
            obj.AddComponent<AKN_SAN_Component>();
        }
    }
}
