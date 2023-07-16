using System;
using System.Collections.Generic;

public class DialogueBroker
{
    // Singleton instance
    private static DialogueBroker instance;

    // List of dialogues
    private List<Dialogue> dialogues = new List<Dialogue>();

    // Private constructor to prevent instantiation
    private DialogueBroker() { }

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

    // Method to add a new dialogue
    public void AddDialogue(Dialogue newDialogue)
    {
        dialogues.Add(newDialogue);
    }

    // Method to remove the first item from the list
    public void RemoveFirstDialogue()
    {
        if (dialogues.Count > 0)
        {
            dialogues.RemoveAt(0);
        }
    }
}

public record Dialogue(string Text, string id, string nextId);
