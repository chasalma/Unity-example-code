using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AKeNe.AI.SteeringBehavior
{
    public class AKN_SmartTerrainSensor : AKN_Sensor<Vector3>
    {

        private Texture2D _m_smartData;

        public AKN_SmartTerrainSensor(GameObject _gameObject)
            : base("Smart Terrain", _gameObject)
        {
        }
        public AKN_SmartTerrainSensor(GameObject _gameObject, Texture2D _smartData)
            : base("Smart Terrain", _gameObject)
        {
            _m_smartData = _smartData;

        }
        public override AKN_Status MUpdate()
        {

            RaycastHit hit;
            Physics.Raycast(_m_gameobject.transform.position, Vector3.down, out hit);
            Vector2 coordUV = hit.textureCoord;
            Color smartColor = _m_smartData.GetPixel((int)(coordUV.x * _m_smartData.width), (int)(coordUV.y * _m_smartData.height));
            Vector3 Couleur = new Vector3(smartColor.r, smartColor.g, smartColor.b);
            _m_output = Couleur;
            Debug.Log("color " + smartColor.r + " " + smartColor.g + " " + smartColor.b);
            m_Active = true;
            return AKN_Status.m_Success;
        }
    }
}
