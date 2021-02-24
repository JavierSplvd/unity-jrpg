using System;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommandSelector : MonoBehaviour
{
    [SerializeField] private CommandButton[] buttons;
    [SerializeField] private float yCoord;

    public delegate void ButtonClicked(int i);
    public event ButtonClicked OnButtonClicked;

    // Start is called before the first frame update
    void Start()
    {
        buttons = transform.GetComponentsInChildren<CommandButton>();
        int i = 0;
        foreach(CommandButton button in buttons)
        {
            Button b = button.GetButton();
            int copy = i; // https://stackoverflow.com/questions/271440/captured-variable-in-a-loop-in-c-sharp
            b.onClick.AddListener(() => {
                if(OnButtonClicked != null)
                {
                    OnButtonClicked(copy);
                }
            });
            i = i + 1;
        }
    }

    void Update()
    {
        
    }

    internal void UpdateCommandSelector(UnitSO unit)
    {
        bool lengthIsCorrect = unit.skills.Length <= 4 && unit.skills.Length >= 0;
        if(!lengthIsCorrect) throw new Exception("UpdateCommandSelector called with incorrect array length.");

        foreach(CommandButton button in buttons)
        {
            Button b = button.GetButton();
            b.interactable = false;
            b.transform.GetChild(0).GetComponent<Text>().text = "";
        }
        int i = 0;
        foreach(SkillSO a in unit.skills)
        {
            buttons[i].Show(unit, a);
            i++;
        }

    }

    internal void ShowCommandSelector(float x)
    {
        Vector2 newPos = new Vector2(x, yCoord);
        GetComponent<RectTransform>().anchoredPosition = newPos;
    }

    internal void HideCommandSelector()
    {
        Vector2 newPos = new Vector2(10000, 10000);
        transform.localPosition = newPos;
        foreach(CommandButton button in buttons)
        {
            Button b = button.GetButton();
            b.interactable = false;
            b.transform.GetChild(0).GetComponent<Text>().text = "";

        }
    }
}
