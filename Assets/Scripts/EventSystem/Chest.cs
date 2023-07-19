using UnityEngine;
using System;

public class Chest : MonoBehaviour
{
    [SerializeField]
    private string eventId = "default";

    void Start()
    {
        EventManager.Instance.SubscribeEvent(eventId, OpenChest);
    }

    void OpenChest()
    {
        Debug.Log("Chest opened! " + eventId);
    }
}