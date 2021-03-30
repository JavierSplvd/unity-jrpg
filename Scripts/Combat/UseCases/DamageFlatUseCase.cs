using System.Linq;

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

        commandParams.GetTargets().ToList().ForEach(target => {
            if(target.currentStatusEffect.Contains(StatusEffect.DEATH))
            {
                return; // If is dead, do not heal or damage.
            }
            new ModifyHPUseCase(target, power).Execute();
            DamageLogger.Add(target.unitId, (int) power);
        });
        return power;
    }
}