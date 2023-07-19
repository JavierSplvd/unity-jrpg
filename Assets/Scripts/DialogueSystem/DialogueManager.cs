using System;
using System.Collections.Generic;
using UnityEngine;

using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit { }
}

public class DialogueManager
{
    private static DialogueManager instance;
    private const string jsonFilePath = "dialogues"; // Path to the JSON file without the .json extension
    private List<Dialogue> all = new List<Dialogue>();
    public event Action<Dialogue> DialogueAdded;

    public void InvokeDialogueEvent(string id)
    {
        Dialogue dialogue = all.Find(d => d.Id == id);
        DialogueAdded?.Invoke(dialogue);
        if (dialogue?.EventId != null)
        {
            EventManager.Instance.InvokeEvent(dialogue.EventId);
        }
    }

    public void InvokeDialogueEvent(Dialogue dialogue)
    {
        DialogueAdded?.Invoke(dialogue);
        if (dialogue?.EventId != null)
        {
            EventManager.Instance.InvokeEvent(dialogue.EventId);
        }
    }

    // Private constructor to prevent instantiation
    private DialogueManager()
    {
        LoadDialogueJson();
    }

    // Singleton instance property
    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DialogueManager();
            }
            return instance;
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
