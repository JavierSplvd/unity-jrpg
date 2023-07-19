using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogueChoicesPresenter : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI textChoice1;
    public TextMeshProUGUI textChoice2;
    public TextMeshProUGUI textChoice3;
    public TextMeshProUGUI textChoice4;
    public GameObject choiceBox1;
    public GameObject choiceBox2;
    public GameObject choiceBox3;
    public GameObject choiceBox4;
    private AudioSource audioSource;
    [Header("DEBUG")]
    [SerializeField]
    private bool isBusy = false;

    public Dialogue dialogue;

    void Start()
    {
        dialogueBox.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        DialogueManager.Instance.DialogueAdded += OnDialogueAdded;
    }

    private void OnDialogueAdded(Dialogue newDialogue)
    {
        if (newDialogue != null && newDialogue.IsChoice == true)
        {
            dialogue = newDialogue;
            StartDisplayDialogue();
        }
        else if (newDialogue == null)
        {
            Debug.LogWarning("Dialogue is null");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.H) && isBusy && dialogue.Choice1 != null)
        {
            dialogueBox.SetActive(false);
            DialogueManager.Instance.AddDialogue(dialogue.NextForChoice1);
            isBusy = false;
        }
        else if (Input.GetKeyUp(KeyCode.J) && isBusy && dialogue.Choice2 != null)
        {
            dialogueBox.SetActive(false);
            DialogueManager.Instance.AddDialogue(dialogue.NextForChoice2);
            isBusy = false;
        }
        else if (Input.GetKeyUp(KeyCode.K) && isBusy && dialogue.Choice3 != null)
        {
            dialogueBox.SetActive(false);
            DialogueManager.Instance.AddDialogue(dialogue.NextForChoice3);
            isBusy = false;
        }
        else if (Input.GetKeyUp(KeyCode.L) && isBusy && dialogue.Choice4 != null)
        {
            dialogueBox.SetActive(false);
            DialogueManager.Instance.AddDialogue(dialogue.NextForChoice4);
            isBusy = false;
        }

    }

    private void StartDisplayDialogue()
    {
        isBusy = true;
        dialogueBox.SetActive(true);
        choiceBox1.SetActive(false);
        choiceBox2.SetActive(false);
        choiceBox3.SetActive(false);
        choiceBox4.SetActive(false);

        if (dialogue.Choice1 != null)
        {
            choiceBox1.SetActive(true);
            textChoice1.text = dialogue.Choice1;
        }
        if (dialogue.Choice2 != null)
        {
            choiceBox2.SetActive(true);
            textChoice2.text = dialogue.Choice2;
        }
        if (dialogue.Choice3 != null)
        {
            choiceBox3.SetActive(true);
            textChoice3.text = dialogue.Choice3;
        }
        if (dialogue.Choice4 != null)
        {
            choiceBox4.SetActive(true);
            textChoice4.text = dialogue.Choice4;
        }
    }

}
