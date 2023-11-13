using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guymon.Utilities
{

    public class CheatCodes : MonoBehaviour
    {
        /// <summary>
        /// Coverts Code to Key Presses
        /// </summary>
        /// <param name="code">String of Characters to Check if Pressed</param>
        /// <returns>Whether All Keys Are Pressed</returns>
        public static bool Code(string code) {
            foreach(char key in code.ToLower().ToCharArray()) {
                if(!Input.GetKey("" + key)) return false;
            }
            return true;
        }
    }
}