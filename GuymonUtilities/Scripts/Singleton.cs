using UnityEngine;
using Guymon.Utilities;
 
namespace Guymon.DesignPatterns {
    /// <summary>
    /// Adds Singleton and MonoBehaviour Properties to a Base Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> : MonoBehaviour
        where T : class
    {
        private static T instance = null;
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static T Instance()
        {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType(typeof(T)) as T;
                    if (instance == null)
                        Guymon.Utilities.Logger.Error("Singleton<T>: Could not find GameObject of type " + typeof(T).Name + " in scene");
                }
                return instance;
        }
    }
}