using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Chest : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    public KeyCode activationKey = KeyCode.J;
    public string targetTag = "Player";
    [SerializeField]
    private Item item;
    private bool isTouchingPlayer = false;
    private bool exhausted = false;
    [Header("Debug")]
    public string randomId;
    [SerializeField]
    private Dialogue dialogue;

    private void LateUpdate()
    {
        if (Input.GetKeyUp(activationKey) && isTouchingPlayer && !exhausted)
        {
            DialogueManager.Instance.InvokeDialogueEvent(
                new Dialogue("Chest" + randomId, "You opened the chest!", randomId)
            );
            exhausted = true;
        }
    }

    void Start()
    {
        randomId = UnityEngine.Random.Range(0, 1000000).ToString();
        EventManager.Instance.SubscribeEvent(randomId, OpenChest);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OpenChest()
    {
        Debug.Log("Chest opened! " + randomId);
        animator.SetTrigger("Open");
        audioSource.Play();
        ItemManager.Instance.AddItem(item);
        // Destroy this component
        Destroy(this);
        Destroy(GetComponent<DialogueProducer>());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger.");
            isTouchingPlayer = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger.");
            isTouchingPlayer = false;
            exhausted = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = true;

        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isTouchingPlayer = false;
            exhausted = false;
        }
    }

}