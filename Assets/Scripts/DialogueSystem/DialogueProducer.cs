using UnityEngine;

public class DialogueProducer : MonoBehaviour
{
    public KeyCode activationKey = KeyCode.J;
    public string targetTag = "Player";
    public string dialogueId = "default";
    private bool isTouchingPlayer = false;
    private bool exhausted = false;

    private void LateUpdate()
    {
        if (Input.GetKeyUp(activationKey) && isTouchingPlayer && !exhausted)
        {
            DialogueManager.Instance.InvokeDialogueEvent(dialogueId);
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

    public string GetDialogueId()
    {
        return dialogueId;
    }
}
