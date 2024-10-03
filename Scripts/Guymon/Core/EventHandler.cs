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
        private static List<EventActionCall> lateAddCalls = new List<EventActionCall>();
        public static void AddListenerLate(string eventID, UnityAction<EventArgs> action) {
            lateAddCalls.Add(new EventActionCall(eventID, action));
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
        private static List<EventActionCall> lateRemoveCalls = new List<EventActionCall>();
        public static void RemoveListenerLate(string eventID, UnityAction<EventArgs> action) {
            lateRemoveCalls.Add(new EventActionCall(eventID, action));
        }
        /// <summary>
        /// Invokes All Methods Attached to the Event ID
        /// </summary>
        /// <param name="eventID">ID of Event</param>
        public static void Invoke(string eventID, EventArgs args) { //params object[] args
            if(!allEvents.ContainsKey(eventID)) return;
            foreach(UnityAction<EventArgs> unityAction in allEvents[eventID]) {
                unityAction?.Invoke(args);
            }

            foreach (EventActionCall call in lateAddCalls)
            {
                AddListener(call.eventID, call.action);
            }
            foreach (EventActionCall call in lateRemoveCalls)
            {
                RemoveListener(call.eventID, call.action);
            }

            lateAddCalls.Clear();
            lateRemoveCalls.Clear();
        }

        private static Dictionary<string, List<UnityAction<EventArgs>>> allEvents = new Dictionary<string, List<UnityAction<EventArgs>>>();
        
    }

    public abstract class EventArgs
    {
        
    }
}



