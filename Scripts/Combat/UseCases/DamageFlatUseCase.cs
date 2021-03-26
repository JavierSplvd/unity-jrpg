using System.Linq;
using static SkillTarget;

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
            power = - ((ItemOffensiveSO) commandParams.GetItem()).power;
        }

        commandParams.GetTargets().ToList().ForEach(it => {
            if(it.currentStatusEffect.Contains(StatusEffect.DEATH))
            {
                return; // If is dead, do not heal.
            }
            new ModifyHPUseCase(it, power).Execute();
            DamageLogger.Add(it.unitId, (int) power);
        });
        return power;
    }
}