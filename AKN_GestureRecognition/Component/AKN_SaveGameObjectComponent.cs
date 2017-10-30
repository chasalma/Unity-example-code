using UnityEngine;
using System.Collections;
using AKeNe.AI.AKN_GestureRecognition;
public class AKN_SaveGameObjectComponent : MonoBehaviour
{

    public GameObject m_gameobject;

    public string m_nameFile = "test1";

    AKN_SaveGameObjectXML _m_file;
    // Use this for initialization
    void Start()
    {
        _m_file = new AKN_SaveGameObjectXML(m_nameFile);
        _m_file.MNewComment("Sauvegarder la position et le quaternion du game object ");
        _m_file.MNewGameObject(m_gameobject);


    }
    void OnApplicationQuit()
    {
        _m_file.MClose();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
