using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

namespace Runtime
{
    public class EventData
    {
    }

    public class EventBus : Singleton<EventBus>
    {
        // Define a simple event handler delegate
        public delegate void EventHandler(EventData eventData);

        // Dictionary to store different event types and their handlers
        private Dictionary<Type, EventHandler> eventHandlers = new Dictionary<Type, EventHandler>();

        // Method to subscribe to an event type
        public static void AddListener<T>(EventHandler handler) where T : EventData
        {
            Type eventType = typeof(T);

            // If the event type is not already in the dictionary, add it
            if (!Instance.eventHandlers.ContainsKey(eventType))
            {
                Instance.eventHandlers[eventType] = null;
            }

            // Add the handler to the event type
            Instance.eventHandlers[eventType] += handler;
        }

        // Method to unsubscribe from an event type
        public static void RemoveListener<T>(EventHandler handler) where T : EventData
        {
            Type eventType = typeof(T);

            // If the event type is in the dictionary, remove the handler
            if (Instance.eventHandlers.ContainsKey(eventType))
            {
                Instance.eventHandlers[eventType] -= handler;
            }
        }

        // Method to publish an event
        public static void Invoke<T>(T eventData) where T : EventData
        {
            Type eventType = typeof(T);
            
            Debug.Log($"EVENT BUS: Event Invoked on channel {eventType} with argument: {eventData}");

            // If the event type is in the dictionary, invoke the handlers
            if (Instance.eventHandlers.ContainsKey(eventType))
            {
                Instance.eventHandlers[eventType]?.Invoke(eventData);
            }
        }
    }
}