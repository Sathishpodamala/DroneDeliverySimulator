using System;
using System.Collections.Generic;
using UnityEngine;

namespace Alpha.Events
{
    public delegate void Callback(System.Object args);
    public static class EventHandler
    {

        public static Dictionary<EventId, Delegate> eventTable = new Dictionary<EventId, Delegate>();


        public static void Subscribe(EventId eventId, Callback callback)
        {
            lock (eventTable)
            {

                if (!eventTable.ContainsKey(eventId))
                {
                    eventTable.Add(eventId, null);
                }

                eventTable[eventId] = (Callback)eventTable[eventId] + callback;
            }
        }

        public static void UnSubscribe(EventId eventId, Callback callback)
        {
            lock (eventTable)
            {
                if (eventTable.ContainsKey(eventId))
                {
                    eventTable[eventId] = (Callback)eventTable[eventId] - callback;

                    if(eventTable[eventId]==null)
                    {
                        eventTable.Remove(eventId);
                    }
                }
            }

        }

        public static void BroadCast(EventId eventId, System.Object payload = null)
        {
            Delegate temp;

            if(eventTable.TryGetValue(eventId,out temp))
            {
                Callback callback = (Callback)temp; //Prevent from race condition

                if(callback!=null)
                {
                    callback.Invoke(payload);
                }


            }
        }

        public static void ClearTable()
        {
            eventTable.Clear();
        }
    }
}
