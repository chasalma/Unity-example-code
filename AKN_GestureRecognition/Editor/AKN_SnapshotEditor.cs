using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[CustomEditor(typeof(AKN_SnapshotComponent))]
public class AKN_SnapshotEditor : Editor
{
    [MenuItem("AKeNe/Gesture Recognition/Snapshot")]
    static void MCreateSnapshot()
    {
        GameObject obj;
        if (Selection.activeGameObject != null)
        {
            obj = Selection.activeGameObject;
        }
        else
        {
            obj = new GameObject("AKN_Snapshot");
        }
        obj.AddComponent<AKN_SnapshotComponent>();
    }

    [MenuItem("AKeNe/Gesture Recognition/XML Recognition")]
    static void MCreateXMLRecognitionComponent()
    {
        GameObject obj;
        if (Selection.activeGameObject != null)
        {
            obj = Selection.activeGameObject;
        }
        else
        {
            obj = new GameObject("AKN_XMLRecognition");
        }
        obj.AddComponent<AKN_XMLRecognitionComponent>();
    }
}
