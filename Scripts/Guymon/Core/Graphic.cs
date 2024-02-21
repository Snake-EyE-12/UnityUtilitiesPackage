using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guymon.Graphics {
    
    public class Graphic : MonoBehaviour
    {
        private void Awake() {
            gameObject.SetActive(false);
        }
    }
}