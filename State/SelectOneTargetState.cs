using System.Linq;
using UnityEngine;

public class SelectOneTargetState : State<BattleSystem>
{
    private CommandParams commandParams;
    private BattleTargetSelector targetSelector;
    private UnitSO target;
    public SelectOneTargetState(BattleSystem owner, CommandParams commandParams) : base(owner)
    {
        this.commandParams = commandParams;
        targetSelector = GameObject.FindObjectOfType<BattleTargetSelector>().GetComponent<BattleTargetSelector>();
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        targetSelector.Show(UnitUtil.GetUnitsFor(commandParams.GetSubject(), base.owner.allUnits, commandParams.GetSkill()));
        targetSelector.OnTargetClicked += Next;
        base.owner.UpdateDialogueText("Choose a target.");
    }

    private void Next(string targetId)
    {
        // Get the target
        UnitSO target = base.owner.allUnits.First(it => it.unitId.Equals(targetId));
        // Create wrapper object with the subject, target and skill
        CommandParams newParams = new CommandParams(commandParams.GetSubject(), target, commandParams.GetItem(), commandParams.GetSkill());
        // Go to the next state: select one target or select item
        base.owner.ChangeState(new AttackState(base.owner, newParams));
    }

    public override void OnStateExit()
    {
        CommandParams newParams = new CommandParams(commandParams.GetSubject(), target, null, commandParams.GetSkill());
        targetSelector.Hide();
    }
}