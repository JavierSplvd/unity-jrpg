using UnityEngine;

[CreateAssetMenu(fileName = "HealSkillSO", menuName = "BattleSystem/HealSkillSO", order = 0)]
public class HealSkillSO : SkillSO {
    public CommandParams commandParams;

    public override void Initialize(CommandParams commandParams)
    {
        this.commandParams = commandParams;
    }

    public override void Execute()
    {
        SoundService.Instance.Play(skillSound);
        HealDealer._obj.Heal(commandParams);
    }
}