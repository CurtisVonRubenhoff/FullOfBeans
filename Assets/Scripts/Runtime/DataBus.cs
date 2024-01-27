using System;
using System.Collections.Generic;


namespace Runtime 
{

    public class DataBus : Singleton<DataBus>
    {
        // Dictionary to store data with a string key
        private Dictionary<string, object> dataStore = new Dictionary<string, object>();

        // Method to set data in the bus
        public static void SetData<T>(string key, T data)
        {
            Instance.dataStore[key] = data;
        }

        // Method to get data from the bus
        public static T GetData<T>(string key)
        {
            if (Instance.dataStore.ContainsKey(key) && Instance.dataStore[key] is T)
            {
                return (T)Instance.dataStore[key];
            }

            // Return default value if the key is not found or the data type doesn't match
            return default(T);
        }

        // Method to check if the bus contains data for a specific key
        public static bool ContainsData(string key)
        {
            return Instance.dataStore.ContainsKey(key);
        }

        // Method to remove data from the bus
        public static void RemoveData(string key)
        {
            if (Instance.dataStore.ContainsKey(key))
            {
                Instance.dataStore.Remove(key);
            }
        }
    }
}