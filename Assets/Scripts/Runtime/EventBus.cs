using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

namespace Runtime
{
    
    public class EventData: GameData {}
    public class EventBus : Singleton<EventBus>
    {
        // Define a simple event handler delegate
        public delegate void EventHandler(EventData eventData);

        // Dictionary to store different event types and their handlers
        private readonly Dictionary<Type, EventHandler> _eventHandlers = new ();

        // Method to subscribe to an event type
        public static void AddListener<T>(EventHandler handler) where T : EventData
        {
            var eventType = typeof(T);

            // If the event type is not already in the dictionary, add it
            Instance._eventHandlers.TryAdd(eventType, null);

            // Add the handler to the event type
            Instance._eventHandlers[eventType] += handler;
        }

        // Method to unsubscribe from an event type
        public static void RemoveListener<T>(EventHandler handler) where T : EventData
        {
            var eventType = typeof(T);

            // If the event type is in the dictionary, remove the handler
            if (Instance._eventHandlers.ContainsKey(eventType))
            {
                Instance._eventHandlers[eventType] -= handler;
            }
        }

        // Method to publish an event
        public static void Invoke<T>(T eventData) where T : EventData
        {
            var eventType = typeof(T);
            
            Debug.Log($"EVENT BUS: Event Invoked on channel {eventType} with argument: {eventData}");

            // If the event type is in the dictionary, invoke the handlers
            if (Instance._eventHandlers.TryGetValue(eventType, out var handler))
            {
                handler(eventData);
            }
        }
    }
}