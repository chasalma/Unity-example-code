using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AKeNe.AI.SteeringBehavior
{
    /**************************************************************************************************
     * Akn view sensor.
     *
     * \author Chaabane Salma
     * \date 15/05/2012
     **************************************************************************************************/

    public class AKN_ViewSensor : AKN_SphericalSensor
    {
        #region Attribut

       /**************************************************************************************************
        * \summary The aov.
        *
        * The aov angle of view
        * il 
        **************************************************************************************************/

       private float _m_aov;
       public float m_aov
       {
           get
           {
               return _m_aov;
           }
       }
       #endregion 

       public AKN_ViewSensor(GameObject _gameObject , float _angleofview , float _distanceofview)
           : base(_gameObject, _distanceofview , "View Sensor")
        {
            _m_aov = _angleofview;
            m_Active = false;
        }

       /**************************************************************************************************
        * Updates this object.
        *  _objectposition =  position de chaque gameobject qui sont dans la sphere de collision
        *  _Angle = angle entre le GameObject principale et le gameobject situé dans la sphere de collision
        *   si _Angle est < de l'angle de vue , dans cet object est dans le champ de vue , si non
        * \author Chaabane Salma
        * \date 18/05/2012
        *
        * \return .
        **************************************************************************************************/

       public new AKN_Status MUpdate()
       {

           Vector3 _DirectionTag;
           float _Angle;
           _m_output.Clear();
           m_Active = false;
           Collider[] _colliders = Physics.OverlapSphere(m_gameobject.transform.position, m_dov);
           if (_colliders.Length <= 1)
           {
               return AKN_Status.m_Failure;
           }
           else
           {
               foreach (Collider c in _colliders)
               {
                   if (c.gameObject != _m_gameobject)
                   {
                       _DirectionTag = c.gameObject.transform.position - _m_gameobject.transform.position;
                       _Angle = Vector3.Angle(_m_gameobject.transform.forward, _DirectionTag);
                       if (_Angle < _m_aov)
                       {
                           _m_output.Add(c.gameObject);
                           m_Active = true;
                       }
                   }
               }
               if (_m_output.Count > 0)
               {
                   return AKN_Status.m_Success;
               }
               else
               {
                   return AKN_Status.m_Failure;
               }
           }
       }
           
    }

}