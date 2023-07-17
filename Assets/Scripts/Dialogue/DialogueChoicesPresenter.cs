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

    public Dialogue dialogue;

    void Start()
    {
        dialogueBox.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (DialogueBroker.Instance.QueueHasItems() && DialogueBroker.Instance.NextHasChoices() == true)
        {
            dialogue = DialogueBroker.Instance.GetFromQueue();
            StartDisplayDialogue();
        }
    }

    private void StartDisplayDialogue()
    {
        dialogueBox.SetActive(true);
        if(dialogue.Choice1 != null)
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
