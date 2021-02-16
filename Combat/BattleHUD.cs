using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour {
    private UnitSO unit;
    public Text nameText;
    public Text levelText;
    public Text hpText;
    public Slider hpSlider;
    public Slider mpSlider;
    public Slider turnCount;
    public Image image;

    void Awake() {
        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Transform c = transform.GetChild(i);
            if(c.name.Equals("Name"))
            {
                nameText = c.gameObject.GetComponent<Text>();
            }
            else if(c.name.Equals("Level"))
            {
                levelText = c.gameObject.GetComponent<Text>();
            }
            else if(c.name.Equals("HP"))
            {
                hpText = c.gameObject.GetComponent<Text>();
            }
            else if(c.name.Equals("HPSlider"))
            {
                hpSlider = c.gameObject.GetComponent<Slider>();
            }
            else if(c.name.Equals("MPSlider"))
            {
                mpSlider = c.gameObject.GetComponent<Slider>();
            }
            else if(c.name.Equals("TurnCount"))
            {
                turnCount = c.gameObject.GetComponent<Slider>();
            }
            else if(c.name.Equals("Image"))
            {
                image = c.gameObject.GetComponent<Image>();
            }
        }

    }

    void FixedUpdate()
    {
        UpdateSliders(unit);
    }

    public void SetHUD(UnitSO unit)
    {
        this.unit = unit;
        nameText.text = unit.unitName;
        levelText.text = "Lvl: " + unit.level;
        UpdateSliders(unit);
        image.sprite = unit.sprite;
        image.rectTransform.sizeDelta = new Vector2(unit.sprite.rect.width, unit.sprite.rect.height);
    }

    public void UpdateSliders(UnitSO unit)
    {
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        hpText.text = unit.currentHP + "/" + unit.maxHP;

        mpSlider.maxValue = unit.maxMP;
        mpSlider.value = unit.currentMP;

        turnCount.maxValue = unit.maxTurnCount;
        turnCount.value = unit.currentTurnCount;
    }
}