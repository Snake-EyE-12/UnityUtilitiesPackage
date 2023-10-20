using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace Guymon.DesignPatterns {
    public static class EventHandler
    {
        /// <summary>
        /// Subscribe a Method to an Event ID
        /// </summary>
        /// <param name="eventID">ID of Event</param>
        /// <param name="action">Event to Subscribe</param>
        public static void AddListener(string eventID, UnityAction action) {
            if(allEvents.ContainsKey(eventID)) allEvents[eventID].Add(action);
            else {
                allEvents.Add(eventID, new List<UnityAction>());
                allEvents[eventID].Add(action);
            }
        }
        /// <summary>
        /// Unsubscribe a Method to an Event ID
        /// </summary>
        /// <param name="eventID">ID of Event</param>
        /// <param name="action">Event to Unsubscribe</param>
        public static void RemoveListener(string eventID, UnityAction action) {
            if(allEvents[eventID] != null) {
                allEvents[eventID].Remove(action);
            }
        }
        /// <summary>
        /// Invokes All Methods Attached to the Event ID
        /// </summary>
        /// <param name="eventID">ID of Event</param>
        public static void Invoke(string eventID) { //params object[] args
            if(!allEvents.ContainsKey(eventID)) return;
            foreach(UnityAction unityAction in allEvents[eventID]) {
                unityAction?.Invoke();
            }
        }

        private static Dictionary<string, List<UnityAction>> allEvents = new Dictionary<string, List<UnityAction>>();
        
    }
}



