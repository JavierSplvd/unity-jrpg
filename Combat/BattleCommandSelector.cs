using System;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommandSelector : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = transform.GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void UpdateCommandSelector(AbilitySO[] abilities)
    {
        bool lengthIsCorrect = abilities.Length <= 4 && abilities.Length >= 0;
        if(!lengthIsCorrect) throw new Exception("UpdateCommandSelector called with incorrect array length.");

        foreach(Button b in buttons)
        {
            b.interactable = false;
            b.transform.GetChild(0).GetComponent<Text>().text = "";
        }
        int i = 0;
        foreach(AbilitySO a in abilities)
        {
            buttons[i].interactable = true;
            // Select the Button, then the Text object.
            Text t = buttons[i].transform.GetChild(0).GetComponent<Text>(); 
            t.text = a.abilityName;
            i++;
        }

    }
}
