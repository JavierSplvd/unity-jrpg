using System.Collections.Generic;
using UnityEngine;

using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit { }
}

public class DialogueBroker
{
    // Singleton instance
    private static DialogueBroker instance;

    private const string jsonFilePath = "dialogues"; // Path to the JSON file without the .json extension

    // List of dialogues
    private List<Dialogue> all = new List<Dialogue>();

    // Queue
    private Queue<string> queue = new Queue<string>();

    // Private constructor to prevent instantiation
    private DialogueBroker()
    {
        LoadDialogueJson();
    }

    // Singleton instance property
    public static DialogueBroker Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DialogueBroker();
            }
            return instance;
        }
    }

    // Method to add a id to the queue
    public void AddDialogueId(string id)
    {
        queue.Enqueue(id);
        Dialogue dialogue = all.Find(d => d.Id == id);
        if (dialogue.NextId != null && dialogue.IsChoice == false)
        {
            AddDialogueId(dialogue.NextId);
        }
        else if (dialogue.NextId != null && dialogue.IsChoice == true)
        {
            queue.Enqueue(dialogue.NextId);
        }
    }

    public Dialogue GetFromQueue()
    {
        if (queue.Count > 0)
        {
            string id = queue.Peek();
            return all.Find(d => d.Id == id);
        }
        else
        {
            return new Dialogue("No dialogue?", "", null, false, null, null, null, null, null, null, null, null);
        }
    }

    public void ConsumeFromQueue()
    {
        queue.Dequeue();
    }

    public bool QueueHasItems()
    {
        return queue.Count > 0;
    }

    public bool NextHasChoices()
    {
        if (queue.Count > 0)
        {
            string id = queue.Peek();
            Dialogue dialogue = all.Find(d => d.Id == id);
            return dialogue.IsChoice;
        }
        else
        {
            return false;
        }
    }

    private void LoadDialogueJson()
    {
        TextAsset jsonString = Resources.Load<TextAsset>(jsonFilePath);
        string asString = jsonString.ToString().Replace("\n", "").Replace("\r", "").Replace("  ", "");
        DialogueJson asObject = JsonUtility.FromJson<DialogueJson>(asString); // Deserialize the JSON string into a list of Dialogue objects
        all.AddRange(asObject.data);
    }
}
