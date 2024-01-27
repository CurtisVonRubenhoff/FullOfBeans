using System;
using System.Collections.Generic;


namespace Runtime 
{

    public class DataBus : Singleton<DataBus>
    {
        // Dictionary to store data with a string key
        private Dictionary<string, object> dataStore = new Dictionary<string, object>();
        private Dictionary<string, Action<object>> valueChangedEvents = new Dictionary<string, Action<object>>();


        // Method to set data in the bus
        public static void Set<T>(string key, T data)
        {
            if (Instance.dataStore.ContainsKey(key) && EqualityComparer<T>.Default.Equals((T)Instance.dataStore[key], data))
            {
                // If the value is the same, don't trigger the event
                return;
            }
            
            Instance.dataStore[key] = data;
            
            // Trigger the value changed event if it exists
            if (Instance.valueChangedEvents.ContainsKey(key))
            {
                Instance.valueChangedEvents[key]?.Invoke(data);
            }
        }

        // Method to get data from the bus
        public static T Get<T>(string key)
        {
            if (Instance.dataStore.ContainsKey(key) && Instance.dataStore[key] is T)
            {
                return (T)Instance.dataStore[key];
            }

            // Return default value if the key is not found or the data type doesn't match
            return default(T);
        }

        // Method to check if the bus contains data for a specific key
        public static bool Any(string key)
        {
            return Instance.dataStore.ContainsKey(key);
        }

        // Method to remove data from the bus
        public static void Delete(string key)
        {
            if (Instance.dataStore.ContainsKey(key))
            {
                Instance.dataStore.Remove(key);
            }
        }
        
        // Method to subscribe to a value changed event
        public static void AddListener(string key, Action<object> callback)
        {
            if (!Instance.valueChangedEvents.ContainsKey(key))
            {
                Instance.valueChangedEvents[key] = null;
            }

            Instance.valueChangedEvents[key] += callback;
        }

        // Method to unsubscribe from a value changed event
        public static void RemoveListener(string key, Action<object> callback)
        {
            if (Instance.valueChangedEvents.ContainsKey(key))
            {
                Instance.valueChangedEvents[key] -= callback;
            }
        }
    }
}