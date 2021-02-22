using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEnemyHUD : MonoBehaviour, IBattleHUD
{
    [SerializeField] private UnitSO unit;
    [SerializeField] private Image image;

    void Awake()
    {
        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Transform c = transform.GetChild(i);
            if(c.name.Equals("Image"))
            {
                image = c.gameObject.GetComponent<Image>();
            }
        }
    }

    void FixedUpdate()
    {
        if(unit == null)
        {
            // Destroy(this);
            throw new System.Exception("Unit is null. This component is destroyed.");
        }
    }

    public void SetUnit(UnitSO unit)
    {
        this.unit = unit;
        image.sprite = unit.sprite;
        image.rectTransform.sizeDelta = new Vector2(unit.sprite.rect.width, unit.sprite.rect.height);
    }

    public void UpdateData(UnitSO unit)
    {
        throw new System.NotImplementedException();
    }

}
