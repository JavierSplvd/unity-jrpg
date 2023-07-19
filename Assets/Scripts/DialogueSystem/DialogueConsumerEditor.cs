// DialogueProducerEditor.cs
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DialogueProducer))]
public class DialogueProducerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DialogueProducer dialogueProducer = (DialogueProducer)target;

        // Load the JSON file from the Resources folder
        TextAsset jsonFile = Resources.Load<TextAsset>("dialogues");
        if (jsonFile == null)
        {
            EditorGUILayout.HelpBox("JSON file not found. Make sure it's placed in a 'Resources' folder.", MessageType.Warning);
            return;
        }

        // Parse the JSON data into an array of Dialogue objects
        DialogueJson dialogues = JsonUtility.FromJson<DialogueJson>(jsonFile.text);

        // Find the dialogue with the selected ID
        Dialogue selectedDialogue = null;
        foreach (Dialogue dialogue in dialogues.data)
        {
            if (dialogue.Id == dialogueProducer.GetDialogueId())
            {
                selectedDialogue = dialogue;
                break;
            }
        }

        if (selectedDialogue == null)
        {
            EditorGUILayout.HelpBox("No dialogue found with the specified ID.", MessageType.Warning);
            return;
        }

        // Display the dialogue text in the editor
        EditorGUILayout.LabelField("Dialogue Id:");
        EditorGUILayout.HelpBox(selectedDialogue.Id, MessageType.None);
        EditorGUILayout.LabelField("Dialogue Text:");
        EditorGUILayout.HelpBox(selectedDialogue.Text, MessageType.None);
        EditorGUILayout.LabelField("Dialogue IsChoice:");
        EditorGUILayout.HelpBox(selectedDialogue.IsChoice.ToString(), MessageType.None);
        EditorGUILayout.LabelField("Dialogue EventId:");
        EditorGUILayout.HelpBox(selectedDialogue.EventId, MessageType.None);
        EditorGUILayout.LabelField("Dialogue NextId:");
        EditorGUILayout.HelpBox(selectedDialogue.NextId, MessageType.None);
        EditorGUILayout.LabelField("Dialogue PortraitName:");
        EditorGUILayout.HelpBox(selectedDialogue.PortraitName, MessageType.None);
    }
}
