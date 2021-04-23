using UnityEngine;
using UnityEngine.UI;

public class BattleEnemyHUD : MonoBehaviour, IBattleHUD {
    [SerializeField] private UnitSO unit;
    [SerializeField] private Image image;
    private SkillAnimation skillAnimation;
    public DamageLogText damageLog;
    public StatusEffectsHUD statusEffects;

    void Awake() {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++) {
            Transform c = transform.GetChild(i);
            if (c.name.Equals("Image")) {
                image = c.gameObject.GetComponent<Image>();
            } else if (c.name.Equals("SkillAnimation")) {
                skillAnimation = c.gameObject.GetComponent<SkillAnimation>();
            } else if (c.name.Equals("DamageLog")) {
                damageLog = c.gameObject.GetComponent<DamageLogText>();
            }
            statusEffects = transform.GetComponentInChildren<StatusEffectsHUD>();
        }
    }

    void FixedUpdate() {
        if (unit == null) {
            // Destroy(this);
            throw new System.Exception("Unit is null. This component is destroyed.");
        }
    }

    public void SetUnit(UnitSO unit) {
        this.unit = unit;
        skillAnimation.SetUnitId(unit.unitId);
        damageLog.SetId(unit.unitId);
        image.sprite = unit.sprite;
        image.rectTransform.sizeDelta = new Vector2(unit.sprite.rect.width, unit.sprite.rect.height);
        statusEffects.Init(unit);
    }

    public void UpdateData(UnitSO unit) {
        throw new System.NotImplementedException();
    }

}