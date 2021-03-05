using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "BasicAttackSkillSO", menuName = "BattleSystem/BasicAttackSkillSO", order = 0)]
public class BasicAttackSkillSO : SkillSO {
    public CommandParams commandParams;

    public override void Initialize(CommandParams commandParams)
    {
        this.commandParams = commandParams;
    }

    public override void Execute()
    {
        commandParams.GetTargets().ToList().ForEach(it => {
            new PlaySkillAnimationUseCase().Execute(it.unitId, commandParams.GetSkill().animationName);
        });
        SoundService.Instance.Play(skillSound);
        DamageDealer._obj.Damage(commandParams);
    }
}