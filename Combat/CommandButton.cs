using UnityEngine;
using UnityEngine.UI;

public class CommandButton : MonoBehaviour {
    private Button button;
    private Text text;

    public Button GetButton() => button;

    void Awake()
    {
        button = GetComponent<Button>();
        text = transform.GetChild(0).GetComponent<Text>();
    }

    public void Show(UnitSO unit, SkillSO skill)
    {
        if(skill.manaCost > unit.currentMP)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }

        if(skill.manaCost == 0)
        {
            text.text = skill.skillName;
        }
        else
        {
            text.text = skill.skillName + "[" + skill.manaCost + "]";
        }   
    }

    public void Hide()
    {
        button.interactable = false;
        text.text = "";
    }
}