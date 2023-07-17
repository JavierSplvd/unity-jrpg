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
    public void AddDialogue(string id)
    {
        queue.Enqueue(id);
        Dialogue dialogue = all.Find(d => d.Id == id);
        if(dialogue.NextId != null)
        {
            AddDialogue(dialogue.NextId);
        }
    }

    // Method to remove the first item from the list
    public Dialogue ConsumeFromQueue()
    {
        if (queue.Count > 0)
        {
            string id = queue.Dequeue();
            return all.Find(d => d.Id == id);
        }
        else
        {
            return new Dialogue("No dialogue?", "", null);
        }
    }

    public bool HasQueue()
    {
        return queue.Count > 0;
    }

    private void LoadDialogueJson()
    {
        TextAsset jsonString = Resources.Load<TextAsset>(jsonFilePath);
        string asString = jsonString.ToString().Replace("\n", "").Replace("\r", "").Replace("  ", "");
        DialogueJson asObject = JsonUtility.FromJson<DialogueJson>(asString); // Deserialize the JSON string into a list of Dialogue objects
        all.AddRange(asObject.data);
    }
}
