using UnityEngine;

[CreateAssetMenu(fileName = "ItemSkillSO", menuName = "BattleSystem/ItemSkillSO", order = 0)]
public class ItemSkillSO : SkillSO
{
    public CommandParams commandParams;
    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Initialize(CommandParams commandParams)
    {
        this.commandParams = commandParams;
    }
}