using UnityEngine;
using UnityEditor;
using Guymon.Components;

[CustomEditor(typeof(Oscillator))]
public class OscillatorEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        if(GUILayout.Button("Reset Transform Position")) (target as Oscillator).transform.localPosition = (target as Oscillator).start;
    }
}