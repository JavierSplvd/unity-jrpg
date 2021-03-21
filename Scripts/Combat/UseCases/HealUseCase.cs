using System.Linq;
using UnityEngine;

public class HealUseCase : UseCase<float> {

    private CommandParams commandParams;

    public HealUseCase(CommandParams commandParams) {
        this.commandParams = commandParams;
    }

    public float Execute() {
        // Modifier should take into account resistances/weaknesess
        float modifier = 1;
        float power = commandParams.GetSkill().power;
        // Decide between physical and magical attack+defense
        bool isMagic = commandParams.GetSkill().isMagical;
        float attack = isMagic? commandParams.GetSubject().magicAttack : commandParams.GetSubject().attack;
        float level = commandParams.GetSubject().level;

        float formulaRes = ((2 * level / 5 + 2) * (power / 50) * (attack / 200) + 2) * modifier;

        commandParams.GetTargets().ToList().ForEach(it => {
            new ModifyHPUseCase(it, formulaRes).Execute();
            DamageLogger.Add(it.unitId, (int) formulaRes);
        });

        return formulaRes;
    }
}