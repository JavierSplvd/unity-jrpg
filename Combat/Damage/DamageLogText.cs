using System;
using UnityEngine;
using UnityEngine.UI;

public class DamageLogText : MonoBehaviour
{
    private Text textElement;
    [SerializeField] private string unitId;

    private UnityUtilities.Countdown timer = new UnityUtilities.Countdown(false, 0.6f);

    void Awake()
    {
        textElement = GetComponent<Text>();
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
            textElement.text = i.ToString();
            timer.Reset();
        }
        
    }

    public void SetId(string unitId) => this.unitId = unitId;
}