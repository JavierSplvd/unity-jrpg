using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageLogText : MonoBehaviour
{
    private TMP_Text textElement;
    [SerializeField] private string unitId;

    private UnityUtilities.Countdown timer = new UnityUtilities.Countdown(false, 0.6f);

    void Awake()
    {
        textElement = GetComponent<TMP_Text>();
        DamageLogger.OnDamageDealt += UpdateText;
        textElement.text = "";
    }

    void FixedUpdate() {
        if(timer.Progress())
        {
            textElement.text = "";
        }
    }

    private void UpdateText(string u, int i)
    {
        if(unitId.Equals(u))
        {
            textElement.text = i > 0? "+" + i.ToString() : i.ToString();
            timer.Reset();
        }
        
    }

    public void SetId(string unitId) => this.unitId = unitId;
}