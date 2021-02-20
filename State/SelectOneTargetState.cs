using System;
using UnityEngine;

public class SelectOneTargetState : State<Battle>
{
    private CommandParams commandParams;
    private BattleTargetSelector targetSelector;
    private UnitSO target;
    public SelectOneTargetState(Battle owner, CommandParams commandParams) : base(owner)
    {
        this.commandParams = commandParams;
        targetSelector = GameObject.FindObjectOfType<BattleTargetSelector>().GetComponent<BattleTargetSelector>();
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        targetSelector.Show(base.owner.allUnits);
        targetSelector.OnTargetClicked += Next;
        base.owner.UpdateDialogueText("Choose a target.");
    }

    private void Next(int i)
    {
        // Get the target
        UnitSO target = base.owner.allUnits[i];
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