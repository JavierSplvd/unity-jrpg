using UnityEngine;

public class DamagePercentageUseCase : UseCase<float> {
    private UnitSO target;
    private float percentage;

    public DamagePercentageUseCase(UnitSO target, float percentage) {
        this.target = target;
        this.percentage = percentage;
    }

    public float Execute() {
        Debug.Log("DamagePercentageUseCase");
        float damage = -target.maxHP * percentage * RandomWrapper.Range(0.2f);
        target.currentHP = Mathf.Clamp(
            target.currentHP + damage,
            0,
            target.maxHP
        );
        DamageLogger.Add(target.unitId, (int) damage);
        return damage;
    }
}