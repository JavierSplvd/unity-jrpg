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
        float damage = -target.finalMaxHP * percentage * RandomWrapper.Range(0.2f);
        new ModifyHPUseCase(target, damage).Execute();
        DamageLogger.Add(target.unitId, (int) damage);
        return damage;
    }
}