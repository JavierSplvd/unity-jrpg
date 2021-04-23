using UnityEngine;

public class ModifyHPUseCase : UseCase<float> {
    private UnitSO unit;
    private float value;

    public ModifyHPUseCase(UnitSO unit, float value) {
        this.unit = unit;
        this.value = value;
    }

    public float Execute() {
        unit.currentHP = Mathf.Clamp(
            unit.currentHP + value,
            0,
            unit.finalMaxHP
        );
        if(unit.currentHP == 0)
        {
            UnitUtil.SetStatusEffect(unit, StatusEffect.DEATH);
        }
        return value;
    }
}