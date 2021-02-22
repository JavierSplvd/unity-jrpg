using System;
using UnityEngine;

public class UnitSelectActionState : State<BattleSystem>
{
    private UnitSO activeUnit;

    public UnitSelectActionState(BattleSystem owner, UnitSO activeUnit) : base(owner)
    {
        this.activeUnit = activeUnit;
    }

    public override void Tick()
    {
        
    }

    public override void OnStateEnter() 
    {
        owner.commandSelector.OnButtonClicked += Next;
        base.owner.UpdateDialogueText("It's " + activeUnit.unitName + " turn. Select an skill.");
        base.owner.UpdateCommandSelector(activeUnit.skills);
        float xCoord = owner.HUDForAlliedUnits[Array.FindIndex(owner.allUnits, row => row == activeUnit)].GetComponent<RectTransform>().localPosition.x;
        base.owner.ShowCommandSelector(xCoord);
    }

    public override void OnStateExit()
    {
        base.owner.HideCommandSelector();
    }

    private void Next(int i)
    {
        // Get the skill
        SkillSO skill = activeUnit.skills[i];
        // Create wrapper object with the skill
        CommandParams commandParams = new CommandParams(activeUnit, null, null, skill);
        // Go to the next state: select one target or select item
        base.owner.ChangeState(new SelectOneTargetState(base.owner, commandParams));
    }
}