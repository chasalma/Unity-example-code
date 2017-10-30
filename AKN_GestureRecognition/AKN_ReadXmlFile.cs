using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;
namespace AKeNe.AI.AKN_GestureRecognition
{
   
    public class AKN_ReadXmlFile
    {
        private XmlTextReader _m_Reader;
        public XmlNodeList m_XmlNodeList;
        private XmlDocument _m_xmlDoc;
        private string _m_FileName;
        public Dictionary<string, GameObject> m_GameObjectDictionary = new Dictionary<string, GameObject>();
        public List<GameObject> m_GameObjectList = new List<GameObject>();
        public AKN_ReadXmlFile(string _fileName)
        {
            _m_xmlDoc = new XmlDocument();
            _m_Reader = new XmlTextReader(AKeNe.AKN_FileOperation.m_AKeNeGesturePath + _fileName);
            _m_Reader.WhitespaceHandling = WhitespaceHandling.None;
            _m_FileName = _fileName;
        }

        public void MRead()
        {

            //   Debug.Log(_fileName + " is readed");
            if (_m_Reader.Read())
            {
                Debug.Log("File Readed");
                _m_xmlDoc.Load(_m_Reader);
                m_XmlNodeList = _m_xmlDoc.GetElementsByTagName("GameObject");

                /************************ Traitement XmlNode *************************/
                 int i = 0;
                 foreach (XmlNode node in m_XmlNodeList)
                 {
                     XmlElement element = (XmlElement)node;
                     string name = element.Attributes["Name"].InnerText;
                     string x = element.GetElementsByTagName("Position")[0].Attributes["x"].InnerText;
                     string y = element.GetElementsByTagName("Position")[0].Attributes["y"].InnerText;
                     string z = element.GetElementsByTagName("Position")[0].Attributes["z"].InnerText;
                     string xp = element.GetElementsByTagName("LocalPosition")[0].Attributes["x"].InnerText;
                     string yp = element.GetElementsByTagName("LocalPosition")[0].Attributes["y"].InnerText;
                     string zp = element.GetElementsByTagName("LocalPosition")[0].Attributes["z"].InnerText;
                     Debug.Log("*Name " + i + " : " + name);
                     i++;
                     Debug.Log("**Position x = " + x + " y= " + y + " z = " + z);
                     Debug.Log("***Local Position x = " + xp + " y= " + yp + " z = " + zp);
                 }
                 
            }
            else
            {
                Debug.Log("Error in reading XML file");
            }
        }
        public void MMakeGameObject()
        {
            foreach (XmlNode node in m_XmlNodeList)
            {
                XmlElement element = (XmlElement)node;

                string name;
                name = element.Attributes["Name"].InnerText;
                GameObject _go = new GameObject(name);
                _go.transform.localScale = new Vector3(1, 1, 1);

                Vector3 position;
                position.x = float.Parse(element.GetElementsByTagName("Position")[0].Attributes["x"].InnerText);
                position.y = float.Parse(element.GetElementsByTagName("Position")[0].Attributes["y"].InnerText);
                position.z = float.Parse(element.GetElementsByTagName("Position")[0].Attributes["z"].InnerText);

                Vector3 localposition;
                localposition.x = float.Parse(element.GetElementsByTagName("LocalPosition")[0].Attributes["x"].InnerText);
                localposition.y = float.Parse(element.GetElementsByTagName("LocalPosition")[0].Attributes["y"].InnerText);
                localposition.z = float.Parse(element.GetElementsByTagName("LocalPosition")[0].Attributes["z"].InnerText);

                _go.transform.position = position;
                _go.transform.localPosition = localposition;
                //Debug.Log(name + " position(" + position.x + "," + position.y + "," + position.z + ") local position(" + localposition.x + "," + localposition.y + "," + localposition .z+ ")");
                //Debug.Log(" position(" + _go.transform.position.x + "," + _go.transform.position.y + "," + _go.transform.position.z + ") local position(" + _go.transform.localPosition.x + "," + _go.transform.localPosition.y + "," + _go.transform.localPosition.z + ")");
                m_GameObjectList.Add(_go);
                m_GameObjectDictionary[name] = _go;
                //Debug.Log("Game Object " + name + " created"); 
            }
        }
    }
    }  