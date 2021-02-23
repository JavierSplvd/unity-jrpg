using UnityEngine;
using UnityEngine.UI;

public class TargetButton : MonoBehaviour {
    private Button button;
    private Text text;
    [SerializeField] private string unitId, unitName;

    void Awake()
    {
        button = GetComponent<Button>();
        text = transform.GetChild(0).GetComponent<Text>();
    }

    public void Hide()
    {
        button.interactable = false;
        text.text = "";
    }

    public void Show(string unitName, string unitId)
    {
        this.unitId = unitId;
        this.unitName = unitName;
        button.interactable = true;
        text.text = unitName;
    }

    public Button GetButton() => button;
    public string GetId() => unitId;
}