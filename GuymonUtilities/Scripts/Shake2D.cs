using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guymon.Components
{
    public class Shake2D : MonoBehaviour
    {
        [SerializeField] private bool shakeable = true;
        [SerializeField] private ShakeType type = ShakeType.Translational_Rotational;
        [SerializeField] private float translationalMagnitude = 1;
        [SerializeField] private float rotationalMagnitude = 10;
        private float currentIntensity;
        private bool stopCurrentShake;
        private Vector3 originalPosition;
        private Vector3 originalRotation;
        [HideInInspector] public bool isShaking => currentIntensity > 0;
        [SerializeField] private AnimationCurve tramaCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        /// <summary>
        /// <para>Shakes the Object, Usually a Camera, Proportional to the Current Intensity Level</para>
        /// Intensity Level is Additive
        /// </summary>
        /// <param name="intensity">Float Between 0 and 1 Inclusive Which Adds to the Current Level of Intensity</param>
        /// <returns>The New Current Level of Shake Intensity</returns>
        public float Shake(float intensity) {
            if(stopCurrentShake) return currentIntensity;
            if(currentIntensity <= 0) {
                originalPosition = transform.position;
                originalRotation = transform.rotation.eulerAngles;
            }
            currentIntensity += intensity;
            return currentIntensity;
        }
        /// <summary>
        /// Activates or Deactivates the Shake of the Object
        /// </summary>
        /// <param name="value">Activates or Deactivates Depending on the Given Value</param>
        public void SetShakeable(bool value) {
            shakeable = value;
            if(shakeable) currentIntensity = 0;
            else stopCurrentShake = true;
        }
        /// <summary>
        /// Sets the Type of Shake for the Object
        /// </summary>
        /// <param name="shakeType">Type of Shake, Translational or Rotational</param>
        public void SetShakeType(ShakeType shakeType) {
            type = shakeType;
            stopCurrentShake = true;
        }
        /// <summary>
        /// Sets the Magnitude of the Shake for the Object
        /// </summary>
        /// <param name="magnitude">Strength of Distance or Maximum Degree</param>
        /// <param name="type">Type of Shake, Translational or Rotational</param>
        public void SetMagnitude(float magnitude, ShakeType type) {
            if((int)type != 1) translationalMagnitude = magnitude;
            if((int)type > 0) rotationalMagnitude = magnitude;
            stopCurrentShake = true;
        }
        private void Update() {
            if(!shakeable) return;

            if(currentIntensity <= 0) return;
        
            currentIntensity = Mathf.Clamp(currentIntensity, 0, 1);
            visiblyShake(currentIntensity);


            currentIntensity -= Time.deltaTime;

            if(currentIntensity <= 0) {
                returnToOriginal();
                stopCurrentShake = false;
            }


        }
        private void returnToOriginal() {
            transform.position = originalPosition;
            transform.rotation = Quaternion.Euler(originalRotation);
        }
        private void visiblyShake(float intensity) {
            float powerT = tramaCurve.Evaluate(intensity) * translationalMagnitude;
            float powerR = tramaCurve.Evaluate(intensity) * rotationalMagnitude;
            if((int)type != 1) transform.position = originalPosition + new Vector3(Random.Range(-powerT, powerT), Random.Range(-powerT, powerT), 0);
            if((int)type > 0) transform.rotation = Quaternion.Euler(originalRotation.x, originalRotation.y, originalRotation.z + Random.Range(-powerR, powerR));
            
        }
    }
    public enum ShakeType
    {
        Translational = 0,
        Rotational = 1,
        Translational_Rotational = 2
    }
}

