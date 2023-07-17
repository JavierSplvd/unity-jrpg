using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialoguePresenter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public GameObject dialogueBox;
    private AudioSource audioSource;

    private Dialogue dialogue;
    public float characterDelay = 1f;
    public GameObject[] portraits;
    [Header("DEBUG")]
    [SerializeField]
    private bool isBusy = false;
    [SerializeField]
    private bool isDisplayingFullMessage = false;

    private Coroutine displayCoroutine;

    void Start()
    {
        dialogueBox.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        DisablePortraits();
    }

    private void DisablePortraits()
    {
        foreach (GameObject portrait in portraits)
        {
            portrait.SetActive(false);
        }
    }

    void Update()
    {
        if (DialogueBroker.Instance.QueueHasItems() && !isBusy && DialogueBroker.Instance.NextHasChoices() == false)
        {
            bool isDifferent = dialogue != null && !DialogueBroker.Instance.GetFromQueue().Id.Equals(dialogue?.Id);
            bool isNull = dialogue is null;
            Debug.Log("from queue: " + DialogueBroker.Instance.GetFromQueue().Id);
            Debug.Log("dialogue: " + dialogue?.Id);
            Debug.Log("isDifferent: " + isDifferent);
            if (isDifferent || isNull)
            {
                dialogue = DialogueBroker.Instance.GetFromQueue();
                StartDisplayDialogue();
            }
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            if (isBusy)
            {
                if (!isDisplayingFullMessage)
                {
                    // Display the full message
                    Debug.Log("isBusy is true and isDisplayingFullMessage is false.");
                    StopCoroutine(displayCoroutine);
                    textMeshPro.text = dialogue.Text.Replace("#", "");
                    isDisplayingFullMessage = true;
                }
                else
                {
                    // Finish displaying and move to the next dialogue
                    Debug.Log("isBusy is true and isDisplayingFullMessage is true.");
                    isBusy = false;
                    dialogueBox.SetActive(false);
                    isDisplayingFullMessage = false;
                    dialogue = null;
                    DialogueBroker.Instance.ConsumeFromQueue();
                    DisablePortraits();
                }
            }
            else if (!isBusy && isDisplayingFullMessage)
            {
                Debug.Log("isBusy is false but isDisplayingFullMessage is true.");
                dialogueBox.SetActive(false);
                isDisplayingFullMessage = false;
                dialogue = null;
                DialogueBroker.Instance.ConsumeFromQueue();
                DisablePortraits();
            }
        }
    }

    public void StartDisplayDialogue()
    {
        isBusy = true;
        isDisplayingFullMessage = false;
        dialogueBox.SetActive(true);
        if (dialogue.PortraitName != null && portraits.Length > 0)
        {
            // convert portraits to a list
            List<GameObject> portraitList = new List<GameObject>(portraits);
            portraitList.Find(p => p.name == dialogue.PortraitName)?.SetActive(true);
        }
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
        isBusy = false;
        isDisplayingFullMessage = true;
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
