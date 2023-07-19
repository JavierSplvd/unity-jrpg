using UnityEngine;

public class DialogueManagerDebugger : MonoBehaviour
{

    public string dialogue;
    void Update()
    {
        dialogue = JsonUtility.ToJson(DialogueManager.Instance.GetFromQueue());
    }
}