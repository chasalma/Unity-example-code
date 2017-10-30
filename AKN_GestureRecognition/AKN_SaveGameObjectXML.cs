using UnityEngine;
using System.Collections;
using System.Xml;
using System.Text;
using System.IO;
using AKeNe;
namespace AKeNe.AI.AKN_GestureRecognition
{
    public class AKN_SaveGameObjectXML
    {
        public XmlTextWriter m_Writer;

        public AKN_SaveGameObjectXML(string _name)
        {
            m_Writer = new XmlTextWriter(AKN_FileOperation.m_AKeNeGesturePath + _name + ".xml", System.Text.Encoding.UTF8);
            m_Writer.Formatting = Formatting.Indented;
            m_Writer.WriteStartDocument(false);
        }

        public void MNewElement(string _name, double _value)
        {
            m_Writer.WriteStartElement(_name);
            m_Writer.WriteAttributeString("value", _value.ToString());
            m_Writer.WriteEndElement();
        }

        public void MNewGameObject(GameObject _gameobject)
        {
            MNewGameObject("", _gameobject);
        }
        public void MNewGameObject(string _name, GameObject _gameobject)
        {
            m_Writer.WriteStartElement("GameObject");

            m_Writer.WriteAttributeString("Name", _name);

            m_Writer.WriteStartElement("Position");
            m_Writer.WriteAttributeString("x", _gameobject.transform.position.x.ToString());
            m_Writer.WriteAttributeString("y", _gameobject.transform.position.y.ToString());
            m_Writer.WriteAttributeString("z", _gameobject.transform.position.z.ToString());
            m_Writer.WriteEndElement();

            m_Writer.WriteStartElement("LocalPosition");
            m_Writer.WriteAttributeString("x", _gameobject.transform.localPosition.x.ToString());
            m_Writer.WriteAttributeString("y", _gameobject.transform.localPosition.y.ToString());
            m_Writer.WriteAttributeString("z", _gameobject.transform.localPosition.z.ToString());
            m_Writer.WriteEndElement();

            m_Writer.WriteEndElement();
            Debug.Log(_name + " ajouté ");
        }
        public void MNewComment(string _comment)
        {
            m_Writer.WriteComment(_comment);
        }
        public void MClose()
        {
            //  _m_file.WriteEndElement();
            m_Writer.Close();
        }

    }
}