#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using Guymon.Components;

[CustomEditor(typeof(Shake2D))]
public class ShakeEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if(GUILayout.Button("Large Shake Test")) (target as Shake2D).Shake(0.75f);
        if(GUILayout.Button("Small Shake Test")) (target as Shake2D).Shake(0.25f);
    }
}
#endif
