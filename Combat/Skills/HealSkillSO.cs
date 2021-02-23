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
        HealDealer._obj.Heal(commandParams);
    }
}