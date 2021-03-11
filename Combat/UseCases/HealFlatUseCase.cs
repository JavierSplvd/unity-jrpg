using System.Linq;
using UnityEngine;

class HealFlatUseCase : UseCase<float> {

    private CommandParams commandParams;
    private float power;

    public HealFlatUseCase(CommandParams commandParams, float value)
    {
        this.commandParams = commandParams;
        this.power = value;
    }

    public float Execute() {
        commandParams.GetTargets().ToList().ForEach(it => {
            it.currentHP = Mathf.Clamp(
                power + it.currentHP,
                0,
                it.maxHP
            );
            DamageLogger.Add(it.unitId, (int) power);
        });
        return power;
    }
}