using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Guymon.Utilities;

namespace Guymon.DesignPatterns {
    /// <summary>
    /// <para>Reuses Deactive GameObjects, Copied From a Prototype, Bound to a Maximum Amount</para>
    /// Note: Deactive Objects Are Released Back into the Pool Automatically
    /// </summary>
    public class ObjectPoolHandler : MonoBehaviour
    {

            
        private class ObjectPool
        {
            private uint maximum;
            private GameObject prototype;
            private List<GameObject> objects = new List<GameObject>();

            public ObjectPool(GameObject actor, uint max) {
                prototype = actor;
                maximum = max;
            }
            public PooledObject get() {
                foreach(GameObject e in objects) {
                    if(!e.activeInHierarchy) {
                        e.SetActive(true);
                        return new PooledObject(e, false);
                    }
                }
                if(objects.Count < maximum) {
                    return new PooledObject(prototype, true);
                }
                else return new PooledObject(null, false);
            }
            public void add(GameObject e) {
                objects.Add(e);
            }
        }
        struct PooledObject
        {
            public GameObject gameObject;
            public bool instantiate;
            public PooledObject(GameObject e, bool i) {
                gameObject = e;
                instantiate = i;
            }
        }







        private static Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();
        /// <summary>
        /// Instantiates a New Pool for a Specified GameObject Type
        /// </summary>
        /// <param name="actor">GameObject Prototype</param>
        /// <param name="id">String ID for Later Creation</param>
        /// <param name="max">Maximum Object Count</param>
        public static void CreatePool(GameObject actor, string id, uint max) {
            if(pools.ContainsKey(id)) {
                Guymon.Utilities.Logger.Error("ObjectPooler: Already Exists a Pool of Type " + id);
                return;
            }
            pools.Add(id, new ObjectPool(actor, max));
        }
        /// <summary>
        /// Instantiates a New Pool for a Specified GameObject Type with ID actor.name
        /// </summary>
        /// <param name="actor">GameObject Prototype</param>
        /// <param name="max">Maximum Object Count</param>
        public static void CreatePool(GameObject actor, uint max) {
            CreatePool(actor, actor.name, max);
        }
        /// <summary>
        /// Instantiates a New Pool for a Specified GameObject Type with MAX uint.MaxValue
        /// </summary>
        /// <param name="actor">GameObject Prototype</param>
        /// <param name="id">String ID for Later Creation</param>
        public static void CreatePool(GameObject actor, string id) {
            CreatePool(actor, id, uint.MaxValue);
        }
        /// <summary>
        /// Instantiates a New Pool for a Specified GameObject Type
        /// </summary>
        /// <param name="actor">GameObject Prototype</param>
        public static void CreatePool(GameObject actor) {
            CreatePool(actor, actor.name, uint.MaxValue);
        }
        
        /// <summary>
        /// Finds an Object From the Pool that can be Used
        /// </summary>
        /// <param name="id">String ID for Pool Look Up</param>
        /// <returns>Newly Active GameObject From the Pool Or Null</returns>
        public static GameObject CreateObject(string id) {
            if(!pools.ContainsKey(id)) {
                Guymon.Utilities.Logger.Error("ObjectPooler: Could not find ObjectPool of Type " + id);
                return null;
            }
            
            PooledObject pooler = pools[id].get();
            GameObject e = null;
            if(pooler.instantiate) {
                e = Instantiate(pooler.gameObject);
                pools[id].add(e);
            }
            else {
                e = pooler.gameObject;
            }
            return e;
        }
    }
}



