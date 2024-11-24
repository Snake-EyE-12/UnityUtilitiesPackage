using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace Guymon.DesignPatterns {
    public static class EventHandler
    {
        private class EventActionCall
        {
            public string eventID;
            public UnityAction<EventArgs> action;
            public EventActionCall(string eventID, UnityAction<EventArgs> action) {
                this.eventID = eventID;
                this.action = action;
            }
        }
        /// <summary>
        /// Subscribe a Method to an Event ID
        /// </summary>
        /// <param name="eventID">ID of Event</param>
        /// <param name="action">Event to Subscribe</param>
        public static void AddListener(string eventID, UnityAction<EventArgs> action) {
            if(allEvents.ContainsKey(eventID)) allEvents[eventID].Add(action);
            else {
                allEvents.Add(eventID, new List<UnityAction<EventArgs>>());
                allEvents[eventID].Add(action);
            }
        }
        
        /// <summary>
        /// Unsubscribe a Method to an Event ID
        /// </summary>
        /// <param name="eventID">ID of Event</param>
        /// <param name="action">Event to Unsubscribe</param>
        public static void RemoveListener(string eventID, UnityAction<EventArgs> action) {
            if(allEvents[eventID] != null) {
                allEvents[eventID].Remove(action);
            }
        }
        
        /// <summary>
        /// Invokes All Methods Attached to the Event ID
        /// </summary>
        /// <param name="eventID">ID of Event</param>
        public static void Invoke(string eventID, EventArgs args) { //params object[] args
            if(!allEvents.ContainsKey(eventID)) return;
            List<UnityAction<EventArgs>> events = new List<UnityAction<EventArgs>>(allEvents[eventID]);
            for(int i = events.Count - 1; i >= 0; i--) {
                if(events[i] == null) {
                    events[i].Invoke(args);
                }
            }
        }
        public static void ClearListeners() {
            allEvents.Clear();
        }

        private static Dictionary<string, List<UnityAction<EventArgs>>> allEvents = new Dictionary<string, List<UnityAction<EventArgs>>>();
        
    }

    public abstract class EventArgs
    {
        
    }
}
