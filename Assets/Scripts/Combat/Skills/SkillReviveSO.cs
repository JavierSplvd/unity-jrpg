using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillReviveSO", menuName = "BattleSystem/SkillReviveSO", order = 0)]
public class SkillReviveSO : SkillSO {
    public CommandParams commandParams;

    public override void Initialize(CommandParams commandParams) {
        this.commandParams = commandParams;
    }

    public override void Execute() {
        commandParams.GetTargets().ToList().ForEach(it => {
            new PlaySkillAnimationUseCase(it.unitId, commandParams.GetSkill().animationName).Execute();
        });
        SoundService.Instance.Play(skillSound);

        commandParams.GetTargets().ToList().ForEach(it =>
            it.currentStatusEffect = it.currentStatusEffect.Where(status => status != StatusEffect.DEATH).ToArray()
        );

        new HealUseCase(commandParams).Execute();
    }
}