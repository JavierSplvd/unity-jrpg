using System;
using UnityEngine;
using static SkillTarget;

public class UnitSelectActionState : State<BattleSystem> {
    private UnitSO activeUnit;

    public UnitSelectActionState(BattleSystem owner, UnitSO activeUnit) : base(owner) {
        this.activeUnit = activeUnit;
    }

    public override void Tick() {

    }

    public override void OnStateEnter() {
        owner.commandSelector.OnButtonClicked += Next;
        base.owner.UpdateDialogueText("It's " + activeUnit.unitName + " turn. Select an skill.");
        base.owner.UpdateCommandSelector(activeUnit);
        float xCoord = owner.HUDForAlliedUnits[Array.FindIndex(owner.allUnits, row => row == activeUnit)].GetComponent<RectTransform>().localPosition.x;
        base.owner.ShowCommandSelector(xCoord);
    }

    public override void OnStateExit() {
        owner.commandSelector.OnButtonClicked -= Next;
        base.owner.HideCommandSelector();
    }

    private void Next(int i) {
        // Get the skill
        SkillSO skill = activeUnit.skills[i];
        // Create wrapper object with the skill
        CommandParams commandParams = new CommandParams(activeUnit, null, skill);
        // Go to the next state: select one target or select item
        if (skill.targeting.Equals(SINGLE_OPPONENT) || skill.targeting.Equals(SINGLE_ALLY) || skill.targeting.Equals(REVIVE)) {
            base.owner.ChangeState(new SelectOneTargetState(base.owner, commandParams));
        } else if (skill.targeting.Equals(SELF)) {
            commandParams = new CommandParams(activeUnit, activeUnit, null, skill);
            base.owner.ChangeState(new AttackState(base.owner, commandParams));
        } else if (skill.targeting.Equals(ITEM_STATE)) {
            base.owner.ChangeState(new SelectItemState(base.owner, owner.GetInventory(), commandParams));
        } else {
            // Multiple opponents or allies
        }

    }
}