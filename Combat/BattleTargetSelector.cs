using System.Linq;
using UnityEngine;

public class BattleTargetSelector : MonoBehaviour
{
    [SerializeField] private TargetButton[] buttons;
    private UnitSO[] allUnits;
    public delegate void ButtonTargetClicked(string i);
    public event ButtonTargetClicked OnTargetClicked;
    
    void Awake()
    {
        buttons = transform.GetComponentsInChildren<TargetButton>();
        int i = 0;
        /* foreach(TargetButton b in buttons)
        {
            string copy = b.GetId(); // https://stackoverflow.com/questions/271440/captured-variable-in-a-loop-in-c-sharp
            b.GetButton().onClick.AddListener(() => {
                if(OnTargetClicked != null)
                {
                    OnTargetClicked(copy);
                }
            });
            i = i + 1;
        } */
    }

    public void Hide()
    {
        Vector2 newPos = new Vector2(10000, 10000);
        transform.localPosition = newPos;
        buttons.ToList().ForEach(it => it.Hide());
    }

    public void Show(UnitSO[] targets)
    {
        Vector2 newPos = new Vector2(0, 0);
        transform.localPosition = newPos;
        for(int i = 0; i < targets.Length; i++)
        {
            buttons[i].Show(targets[i].unitName, targets[i].unitId);
            string copy = targets[i].unitId;
            buttons[i].GetButton().onClick.RemoveAllListeners();
            buttons[i].GetButton().onClick.AddListener(() => {
                if(OnTargetClicked != null)
                {
                    OnTargetClicked(copy);
                }
            });
        }
    }
}
