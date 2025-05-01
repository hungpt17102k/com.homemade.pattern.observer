using System;
using System.Collections.Generic;
using com.homemade.pattern.singleton;

namespace com.homemade.pattern.observer
{
    public class Observer : LiveSingleton<Observer>
    {
        private Dictionary<object, Action<object>> listeners = new Dictionary<object, Action<object>>();

        public override void OnDestroy()
        {
            ClearAllListener();
        }

        public void ClearAllListener()
        {
            listeners.Clear();
        }

        public void RegisterListener(object eventID, Action<object> callback)
        {
            if (!listeners.ContainsKey(eventID))
                listeners.Add(eventID, null);

            listeners[eventID] += callback;
        }

        public void RemoveListener(object eventID, Action<object> callback)
        {
            if (!listeners.ContainsKey(eventID)) return;
            if (callback == null) return;

            listeners[eventID] -= callback;
        }

        public void PostEvent(object eventID, object param = null)
        {
            if (!listeners.ContainsKey(eventID)) return;

            var callbacks = listeners[eventID];
            if (callbacks != null) callbacks(param);
            else listeners.Remove(eventID);
        }
    }
}