using System.Linq;
using UnityEngine;

public class DamageUseCase : UseCase<float> {
    private CommandParams commandParams;

    public DamageUseCase(CommandParams commandParams) {
        this.commandParams = commandParams;
    }

    private float DamageOne(UnitSO subject, UnitSO target, SkillSO skill) {
        // Modifier should take into account resistances/weaknesess
        float modifier = 1;
        bool containsElement = target.elementalWeakness.ContainsKey(skill.element);
        if (containsElement) {
            modifier = target.elementalWeakness[skill.element] / 100f;
        }
        float power = skill.power;
        // Decide between physical and magical attack+defense
        bool isMagic = skill.isMagical;
        float attack = isMagic? subject.finalMagicAttack : subject.finalAttack;
        float defense = isMagic? subject.finalMagicDefense : target.finalDefense;
        float level = subject.level;

        float formulaRes = ((2 * level / 5 + 2) * (power / 50) * (attack / defense) + 2) * modifier * RandomWrapper.Range(0.2f);

        new ModifyHPUseCase(target, -formulaRes).Execute();
        DamageLogger.Add(target.unitId, (int) - formulaRes);
        return formulaRes;
    }

    public float Execute() {
        float total = 0;
        commandParams.GetTargets().ToList().ForEach(it => {
            total += DamageOne(commandParams.GetSubject(), it, commandParams.GetSkill());
        });

        return total;
    }
}