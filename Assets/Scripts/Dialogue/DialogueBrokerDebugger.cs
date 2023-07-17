using UnityEngine;

public class DialogueBrokerDebugger : MonoBehaviour
{

    public string dialogue;
    void Update()
    {
        dialogue = JsonUtility.ToJson(DialogueBroker.Instance.GetFromQueue());
    }
}