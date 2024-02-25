using System;
using UnityEngine;
using Guymon.Utilities;
 
namespace Guymon.DesignPatterns {
    /// <summary>
    /// Adds Singleton and MonoBehaviour Properties to a Sub Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> : MonoBehaviour
        where T : class
    {
        private static T instance = null;
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static T Instance
        {
	        get
	        {
		        if (instance == null)
		        {
			        instance = GameObject.FindObjectOfType(typeof(T)) as T;
#if UNITY_EDITOR
			        if (instance == null) {
				        Guymon.Utilities.Console.Error("Singleton<T>: Could not find GameObject of type " + typeof(T).Name + " in scene");
			        }
#endif
		        }

		        return instance;
	        }
        }
	private void OnDestroy()
        {
	        instance = null;
        }
    }
}
