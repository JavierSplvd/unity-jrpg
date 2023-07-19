using UnityEngine;
using System;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    // Dictionary to store event names and their associated event handlers
    private Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    // Getter for the singleton instance
    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Look for an existing EventManager instance in the scene
                instance = FindObjectOfType<EventManager>();

                if (instance == null)
                {
                    // Create a new EventManager object if it doesn't exist
                    GameObject eventManagerObject = new GameObject("EventManager");
                    instance = eventManagerObject.AddComponent<EventManager>();
                }
            }

            return instance;
        }
    }

    // Method to subscribe to an event
    public void SubscribeEvent(string eventName, Action eventHandler)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            // Add the event handler to the existing event
            eventDictionary[eventName] += eventHandler;
        }
        else
        {
            // Create a new event with the event handler
            eventDictionary[eventName] = eventHandler;
        }
    }

    // Method to unsubscribe from an event
    public void UnsubscribeEvent(string eventName, Action eventHandler)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            // Remove the event handler from the event
            eventDictionary[eventName] -= eventHandler;
        }
    }

    // Method to invoke an event
    public void InvokeEvent(string eventName)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            // Invoke all event handlers associated with the event
            eventDictionary[eventName]?.Invoke();
        }
    }
}
