using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class BattleItemSelector : MonoBehaviour
{
    private ItemButton[] buttons;
    private Vector2 originalPosition;

    void Awake()
    {
        originalPosition = GetComponent<RectTransform>().anchoredPosition;
        buttons = transform.GetComponentsInChildren<ItemButton>();
    }

    public void Hide()
    {
        Vector2 newPos = new Vector2(10000, 10000);
        transform.localPosition = newPos;
        buttons.ToList().ForEach(it => {
            it.Hide();
        });
    }

    public void Show(ItemSO[] items)
    {
        GetComponent<RectTransform>().anchoredPosition = originalPosition;

        int buttonsCount = buttons.Length;
        int itemsCount = items.Length;
        if(itemsCount > buttonsCount)
        {
            throw new System.Exception("BattleItemSelector there are more items than buttons.");
        }
        for(int i = 0; i < itemsCount; i++)
        {
            buttons[i].Show(items[i]);
        }
        
    }
}
