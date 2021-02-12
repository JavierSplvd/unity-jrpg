using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour {
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;

    public void SetHUD(UnitSO unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.level;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void UpdateHP(UnitSO unit)
    {
        hpSlider.value = unit.currentHP;
    }
}