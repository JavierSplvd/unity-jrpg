using UnityEngine;

public class DialogueProducer : MonoBehaviour
{
    public KeyCode activationKey = KeyCode.J;
    public string targetTag = "Player";
    public string dialogueId = "test";
    private bool isTouchingPlayer = false;
    private bool exhausted = false;

    private void Update()
    {
        if (Input.GetKeyUp(activationKey) && isTouchingPlayer && !exhausted)
        {
            Debug.Log("Player pressed the activation key.");
            DialogueBroker.Instance.AddDialogueId(dialogueId);
            exhausted = true;
        }
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
            Debug.Log("Player entered the trigger.");
            isTouchingPlayer = true;

        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger.");
            isTouchingPlayer = false;
            exhausted = false;
        }
    }
}
