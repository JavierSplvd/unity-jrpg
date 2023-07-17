using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialoguePresenter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public GameObject dialogueBox;
    private AudioSource audioSource;

    public Dialogue dialogue;
    public float characterDelay = 1f;
    private bool isBusy = false;
    private bool isDisplayingFullMessage = false;

    private Coroutine displayCoroutine;

    void Start()
    {
        dialogueBox.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (DialogueBroker.Instance.HasQueue() && !isBusy)
        {
            dialogue = DialogueBroker.Instance.ConsumeFromQueue();
            StartDisplayDialogue();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (isBusy)
            {
                if (!isDisplayingFullMessage)
                {
                    // Display the full message
                    StopCoroutine(displayCoroutine);
                    textMeshPro.text = dialogue.Text.Replace("#", "");
                    isDisplayingFullMessage = true;
                }
                else
                {
                    // Finish displaying and move to the next dialogue
                    isBusy = false;
                    dialogueBox.SetActive(false);
                    isDisplayingFullMessage = false;
                }
            }
            else
            {
                Debug.Log("Player pressed the activation key.");
                dialogue = null;
                dialogueBox.SetActive(false);
            }
        }
    }

    public void StartDisplayDialogue()
    {
        isBusy = true;
        dialogueBox.SetActive(true);
        if (displayCoroutine != null)
        {
            StopCoroutine(displayCoroutine);
        }

        displayCoroutine = StartCoroutine(DisplayDialogue());
    }

    private IEnumerator DisplayDialogue()
    {
        textMeshPro.text = string.Empty;

        for (int i = 0; i < dialogue.Text.Length; i++)
        {
            char v = dialogue.Text[i];
            if (v == '#')
            {
                textMeshPro.text += "";
            }
            else
            {
                textMeshPro.text += v;
                audioSource.Play();
                audioSource.pitch = AssignPitchValue(v);
            }

            yield return new WaitForSeconds(characterDelay);
        }
        isDisplayingFullMessage = false;
    }

    private float AssignPitchValue(char character)
    {
        float pitch = 1f; // Default pitch value

        // Assign pitch based on the character value
        if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')
        {
            pitch = 2f;
        }

        return pitch;
    }
}
