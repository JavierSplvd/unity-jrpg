using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(DialogueProducer))]
public class Chest : MonoBehaviour
{
    [SerializeField]
    private string eventId = "default";
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        EventManager.Instance.SubscribeEvent(eventId, OpenChest);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OpenChest()
    {
        Debug.Log("Chest opened! " + eventId);
        animator.SetTrigger("Open");
        audioSource.Play();
        ItemManager.Instance.AddItem(new Item("Health Potion", ItemType.Potion));
        // Destroy this component
        Destroy(this);
        Destroy(GetComponent<DialogueProducer>());
    }
}