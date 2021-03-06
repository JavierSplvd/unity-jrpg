using System;
using UnityEngine;
using UnityEngine.UI;

public class DamageLogText : MonoBehaviour
{
    private Text textElement;

    void Awake()
    {
        textElement = GetComponent<Text>();
        DamageLogger.OnDamageDealt += UpdateText;
    }

    private void UpdateText(string u, int i)
    {
        textElement.text = i.ToString();
    }
}