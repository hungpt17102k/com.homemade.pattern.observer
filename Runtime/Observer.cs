using System;
using System.Collections.Generic;
using com.homemade.pattern.singleton;

namespace com.homemade.pattern.observer
{
    public class Observer : MonoSingleton<Observer>
    {
        private Dictionary<string, Action<object>> listeners = new Dictionary<string, Action<object>>();

        public override void OnDestroy()
        {
            base.OnDestroy();

            ClearAllListener();
        }

        public void ClearAllListener()
        {
            listeners.Clear();
        }

        public void RegisterListener(string eventID, Action<object> callback)
        {
            if (!listeners.ContainsKey(eventID))
                listeners.Add(eventID, null);

            listeners[eventID] += callback;
        }

        public void RemoveListener(string eventID, Action<object> callback)
        {
            if (!listeners.ContainsKey(eventID)) return;
            if (callback == null) return;

            listeners[eventID] -= callback;
        }

        public void PostEvent(string eventID, object param = null)
        {
            if (!listeners.ContainsKey(eventID)) return;

            var callbacks = listeners[eventID];
            if (callbacks != null) callbacks(param);
            else listeners.Remove(eventID);
        }
    }
}