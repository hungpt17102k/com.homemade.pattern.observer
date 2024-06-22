using System;
using UnityEngine;

namespace com.homemade.pattern.observer
{
    public static class ObserverExtension
    {
        public static void RegisterListener(this MonoBehaviour listener, string eventID, Action<object> callback)
        {
            Observer.Instance?.RegisterListener(eventID, callback);
        }

        public static void RemoveListener(this MonoBehaviour listener, string eventID, Action<object> callback)
        {
            Observer.Instance?.RemoveListener(eventID, callback);
        }

        public static void PostEvent(this MonoBehaviour sender, string eventID, object param = null)
        {
            Observer.Instance?.PostEvent(eventID, param);
        }
    }
}
