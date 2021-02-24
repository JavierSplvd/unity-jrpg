using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    private Button button;
    private Text text;
    
    void Awake()
    {
        button = GetComponent<Button>();
        text = transform.GetChild(0).GetComponent<Text>();
    }

    internal void Hide()
    {
        button.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
        button.interactable = false;
        text.text = "";
    }

    internal void Show(ItemSO item)
    {
        button.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        button.interactable = true;
        text.text = item.itemName + "<b>x" + item.quantity + "</b>";
    }
}
