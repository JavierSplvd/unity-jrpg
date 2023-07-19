using NUnit.Framework;
using UnityEngine;

public class DialogueManagerTest
{
    private bool dialogueAddedEventInvoked;

    [Test]
    public void DialogueAddedEvent_SubscribeAndCheckInvocation()
    {
        // Arrange
        dialogueAddedEventInvoked = false;
        DialogueManager dialogueManager = DialogueManager.Instance;

        // Subscribe to the DialogueAdded event
        dialogueManager.DialogueAdded += OnDialogueAdded;

        // Act
        // Invoke the DialogueEvent (Replace "YourDialogueId" with the desired dialogue ID from your JSON)
        dialogueManager.InvokeDialogueEvent("YourDialogueId");

        // Assert
        // Check if the event was invoked
        Assert.IsTrue(dialogueAddedEventInvoked, "DialogueAdded event was not invoked.");

        // Clean up (important to prevent interference with other tests)
        dialogueManager.DialogueAdded -= OnDialogueAdded;
    }

    // Event handler for DialogueAdded event
    private void OnDialogueAdded(Dialogue dialogue)
    {
        dialogueAddedEventInvoked = true;
        // You can add further assertions on the dialogue object if needed
    }
}
