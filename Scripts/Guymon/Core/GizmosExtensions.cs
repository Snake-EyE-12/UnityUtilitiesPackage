using UnityEngine;

namespace Guymon.Utilities {
    public static class GizmosExtensions
    {
        /// <summary>
        /// Draws a wire arc.
        /// </summary>
        /// <param name="center">The center of the circle the arc lies on</param>
        /// <param name="forwardDirection">The direction from which the midpoint of the arc starts</param>
        /// <param name="normalDirection">The direction of view for the arc</param>
        /// <param name="angle">The full angle of the arc in degrees</param>
        /// <param name="radius">The distance from the center to start the arc</param>
        /// <param name="maxSteps">How many steps to use to draw the arc.</param>
        public static void DrawWireArc(Vector3 center, Vector3 forwardDirection, Vector3 normalDirection, float angle, float radius, float maxSteps = 20)
        {
            Vector3 centerArc = (forwardDirection.normalized * radius) + center;
            Vector3 startArc = (Quaternion.AngleAxis(angle * 0.5f, normalDirection) * (centerArc - center)).normalized * radius + center;
            Gizmos.DrawLine(center, startArc);

            float stepAngle = angle/(maxSteps);
            Vector3 previousStepArc = startArc;
            for(int i = 0; i < maxSteps + 1; i++) { //(angle * 0.5f) - 
                Vector3 stepArc = (Quaternion.AngleAxis((stepAngle * -i), normalDirection.normalized) * (startArc - center)).normalized * radius + center;
                Gizmos.DrawLine(previousStepArc, stepArc);
                previousStepArc = stepArc;
            }
            Gizmos.DrawLine(previousStepArc, center);
        }
    }
}