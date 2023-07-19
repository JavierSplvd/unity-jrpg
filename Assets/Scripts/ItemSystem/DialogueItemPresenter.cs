using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueItemPresenter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    [SerializeField]
    private Image background;

    void Start()
    {
        ItemManager.Instance.ItemAdded += OnItemAdded;
        textMeshPro.text = "";
        background.enabled = false;
    }

    private void OnItemAdded(Item item)
    {
        textMeshPro.text = "You obtained " + item.Name;
        background.enabled = true;
        // After 5 seconds, clear the text
        Invoke("ClearText", 2.5f);
    }

    private void ClearText()
    {
        textMeshPro.text = "";
        background.enabled = false;
    }
}