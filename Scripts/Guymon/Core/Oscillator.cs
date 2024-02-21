using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Guymon.Utilities;

namespace Guymon.Components {
    /// <summary>
    /// Moves a GameObject on a Path Between 2 Points Over Time
    /// </summary>
    public class Oscillator : MonoBehaviour
    {
        [SerializeField] private bool symetric = true;
        [SerializeField] private AnimationCurve movementPattern = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] [Tooltip("Seconds")] private float time = 1;
        public Vector3 start;
        public Vector3 end;
        [SerializeField] private Color gizmoColor = new Color(1,0,0,0.5f);
        private float elapsedTime;

        private void Start() {
            elapsedTime = time;
        }
        private void Update() {
            if(time <= 0) {
                #if UNITY_EDITOR
                Guymon.Utilities.Console.Error("Oscillator: Time can not be less than or equal to 0");
                #endif
                return;
            }
            elapsedTime -= Time.deltaTime;
            transform.localPosition = (!symetric || elapsedTime >= 0) ? Vector3.Lerp(start, end, movementPattern.Evaluate(((time - Mathf.Abs(elapsedTime))/time))) : Vector3.Lerp(end, start, movementPattern.Evaluate(1 - ((time - Mathf.Abs(elapsedTime))/time)));
            if(elapsedTime <= -time) elapsedTime = time;
        }
        private void OnDrawGizmosSelected() {
            Gizmos.color = gizmoColor;
            if(transform.parent) {
                Gizmos.DrawLine(transform.parent.position + start, transform.parent.position + end);
            }
            else Gizmos.DrawLine(start, end);
        }
    }
}