using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour, IBattleHUD
{
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
        if(unit == null)
        {
            Destroy(this);
            throw new System.Exception("Unit is null. This component is destroyed.");
        }
        UpdateData(unit);
    }

    public void SetUnit(UnitSO unit)
    {
        this.unit = unit;
        nameText.text = unit.unitName;
        levelText.text = "Lvl: " + unit.level;
        UpdateData(unit);
        image.sprite = unit.sprite;
        image.rectTransform.sizeDelta = new Vector2(unit.sprite.rect.width, unit.sprite.rect.height);
    }

    public void UpdateData(UnitSO unit)
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