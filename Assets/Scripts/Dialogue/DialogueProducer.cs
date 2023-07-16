using UnityEngine;

public class DialogueProducer : MonoBehaviour
{
    public KeyCode activationKey = KeyCode.J;
    public string targetTag = "Player";
    public string dialogueId = "test";

    private void Update()
    {
        if (Input.GetKeyDown(activationKey) && IsPlayerColliding())
        {
            DialogueBroker.Instance.AddDialogue(new Dialogue("Hello, world!", dialogueId, null));
        }
    }

    private bool IsPlayerColliding()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f, Quaternion.identity);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                return true;
            }
        }

        return false;
    }
}
