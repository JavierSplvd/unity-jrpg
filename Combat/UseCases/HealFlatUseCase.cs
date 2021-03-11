using System.Linq;
using UnityEngine;

public class HealFlatUseCase : UseCase<float> {

    private CommandParams commandParams;

    public HealFlatUseCase(CommandParams commandParams)
    {
        this.commandParams = commandParams;
    }

    public float Execute() {
        float power = 0f;
        if(commandParams.GetSkill() != null)
        {
            power = commandParams.GetSkill().power;
        }
        else if (commandParams.GetItem() != null)
        {
            power = ((ItemHealingSO) commandParams.GetItem()).power;
        }

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