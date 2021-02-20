using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTargetSelector : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    private UnitSO[] allUnits;
    public delegate void ButtonTargetClicked(int i);
    public event ButtonTargetClicked OnTargetClicked;
    // Start is called before the first frame update
    void Awake()
    {
        buttons = transform.GetComponentsInChildren<Button>();
        int i = 0;
        foreach(Button b in buttons)
        {
            int copy = i; // https://stackoverflow.com/questions/271440/captured-variable-in-a-loop-in-c-sharp
            b.onClick.AddListener(() => {
                if(OnTargetClicked != null)
                {
                    OnTargetClicked(copy);
                }
            });
            i = i + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        Vector2 newPos = new Vector2(10000, 10000);
        transform.localPosition = newPos;
        foreach(Button b in buttons)
        {
            b.interactable = false;
            b.transform.GetChild(0).GetComponent<Text>().text = "";
        }
    }

    public void Show(UnitSO[] targets)
    {
        Vector2 newPos = new Vector2(0, 0);
        transform.localPosition = newPos;
        for(int i = 0; i < targets.Length; i++)
        {
            Button b = buttons[i];
            b.interactable = true;
            b.transform.GetChild(0).GetComponent<Text>().text = targets[i].unitName;
        }
    }
}
