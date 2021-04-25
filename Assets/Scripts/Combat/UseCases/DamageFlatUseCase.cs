using System.Linq;
using UnityEngine;

public class DamageFlatUseCase : UseCase<float> {

    private CommandParams commandParams;

    public DamageFlatUseCase(CommandParams commandParams)
    {
        this.commandParams = commandParams;
    }

    public float Execute() {
        float total = 0;
        commandParams.GetTargets().ToList().ForEach(target => {
            if(target.currentStatusEffect.Contains(StatusEffect.DEATH))
            {
                return; // If is dead, do not heal or damage.
            }
            float power = GetPower(target);
            total += power;
            new ModifyHPUseCase(target, power).Execute();
            DamageLogger.Add(target.unitId, (int) power);
        });
        return total;
    }

    public float GetPower(UnitSO target)
    {
        float power = 0f;

        if(commandParams.GetSkill() != null)
        {
            if(commandParams.GetSkill().targeting.Equals(SkillTarget.SINGLE_ALLY) ||
                commandParams.GetSkill().targeting.Equals(SkillTarget.MULTIPLE_ALLIES))
            {
                power = commandParams.GetSkill().power;
            }
            else
            {
                power = - commandParams.GetSkill().power;
            }
            
        }
        else if (commandParams.GetItem().GetType() == typeof(ItemHealingSO))
        {
            power = ((ItemHealingSO) commandParams.GetItem()).power;
        }
        else if (commandParams.GetItem().GetType() == typeof(ItemOffensiveSO))
        {
            var item = (ItemOffensiveSO) commandParams.GetItem();
            float modifier = target.elementalWeakness[item.element];
            power = - item.power;
        }

        return power;
    }
}