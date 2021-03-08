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
    public SkillAnimation skillAnimation;

    void Awake() {
        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if(child.name.Equals("Name"))
            {
                nameText = child.gameObject.GetComponent<Text>();
            }
            else if(child.name.Equals("Level"))
            {
                levelText = child.gameObject.GetComponent<Text>();
            }
            else if(child.name.Equals("HP"))
            {
                hpText = child.gameObject.GetComponent<Text>();
            }
            else if(child.name.Equals("HPSlider"))
            {
                hpSlider = child.gameObject.GetComponent<Slider>();
            }
            else if(child.name.Equals("MPSlider"))
            {
                mpSlider = child.gameObject.GetComponent<Slider>();
            }
            else if(child.name.Equals("TurnCount"))
            {
                turnCount = child.gameObject.GetComponent<Slider>();
            }
            else if(child.name.Equals("Image"))
            {
                image = child.gameObject.GetComponent<Image>();
            }
            else if(child.name.Equals("SkillAnimation"))
            {
                skillAnimation = child.gameObject.GetComponent<SkillAnimation>();
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
        skillAnimation.SetUnitId(unit.unitId);
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