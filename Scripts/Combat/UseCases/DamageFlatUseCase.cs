using System.Linq;
using UnityEngine;

public class DamageFlatUseCase : UseCase<float> {

    private CommandParams commandParams;

    public DamageFlatUseCase(CommandParams commandParams)
    {
        this.commandParams = commandParams;
    }

    public float Execute() {
        float power = 0f;
        if(commandParams.GetSkill() != null)
        {
            power = commandParams.GetSkill().power;
        }
        else if (commandParams.GetItem().GetType() == typeof(ItemHealingSO))
        {
            power = ((ItemHealingSO) commandParams.GetItem()).power;
        }
        else if (commandParams.GetItem().GetType() == typeof(ItemOffensiveSO))
        {
            power = ((ItemOffensiveSO) commandParams.GetItem()).power;
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