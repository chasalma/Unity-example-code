using UnityEngine;
using System.Collections;
using AKeNe.AI.AKN_GestureRecognition;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.IO;

public class AKN_ReadXmlComponent : MonoBehaviour
{

    AKN_ReadXmlFile _m_xmlfile;
    XmlNode _m_xmlNode;

    public string m_FileName = "salut1.xml";

    public string m_FileName = "test1.xml";


    void Start()
    {
        _m_xmlfile = new AKN_ReadXmlFile();
        _m_xmlfile.MRead(m_FileName);

        }
    public string m_FileName = "FileName2.xml";

void Start()
{
    _m_xmlfile = new AKN_ReadXmlFile();

    //  _m_xmlNode = _m_xmlfile.m_XmlNode ;
}

// Update is called once per frame
void Update()
{

    _m_xmlfile.MRead(m_FileName);

}

    List<AKN_ReadXmlFile> _m_xmlfilelist = new List<AKN_ReadXmlFile>();
XmlNode _m_xmlNode;
// Use this for initialization
// public string m_FileName = "salut1.xml";
public List<string> m_fileName = new List<string>();
void Start()
{
    foreach (string name in m_fileName)
    {
        AKN_ReadXmlFile _m_xmlfile = new AKN_ReadXmlFile(name);
        _m_xmlfilelist.Add(_m_xmlfile);

    }
    foreach (AKN_ReadXmlFile _xml in _m_xmlfilelist)
    {
        _xml.MRead();
        _xml.MMakeGameObject();
    }
}

void Update()
{

}
}
