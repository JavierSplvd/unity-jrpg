using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour {
    public Text nameText;
    public Text levelText;
    public Text hpText;
    public Slider hpSlider;

    public void SetHUD(UnitSO unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl: " + unit.level;
        UpdateHP(unit);
    }

    public void UpdateHP(UnitSO unit)
    {
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        hpText.text = unit.currentHP + "/" + unit.maxHP;
    }
}