using System;
using System.Collections.Generic;
using System.Linq;

public class EventBus
{
    private static EventBus instance;
    public static EventBus Instance => instance ??= new EventBus();

    private readonly Dictionary<Type, List<Delegate>> subscribers = new();

    public void Subscribe<T>(Action<T> handler)
    {
        if (!subscribers.TryGetValue(typeof(T), out var handlers))
        {
            handlers = new List<Delegate>();
            subscribers[typeof(T)] = handlers;
        }
        handlers.Add(handler);
    }

    public void Unsubscribe<T>(Action<T> handler)
    {
        if (subscribers.TryGetValue(typeof(T), out var handlers))
        {
            handlers.Remove(handler);
            if (handlers.Count == 0)
                subscribers.Remove(typeof(T));
        }
    }

    public void Broadcast<T>(T eventData)
    {
        if (subscribers.TryGetValue(typeof(T), out var handlers))
        {
            foreach (var handler in handlers.Cast<Action<T>>())
            {
                handler(eventData);
            }
        }
    }
}