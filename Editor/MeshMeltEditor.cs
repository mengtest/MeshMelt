using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MeshMelt))]
public class MeshMeltEditor : Editor{

    public void OnEnable()
    {
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
