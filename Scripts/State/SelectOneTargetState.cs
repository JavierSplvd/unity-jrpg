using System.Linq;
using UnityEngine;
using static SkillTarget;

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
        bool offensive = false;
        if (commandParams.GetItem() != null)
        {
            offensive = commandParams.GetItem().targeting.Equals(SINGLE_OPPONENT) || commandParams.GetItem().targeting.Equals(MULTIPLE_OPPONENTS);
        }
        else if (commandParams.GetSkill() != null)
        {
            offensive = commandParams.GetSkill().targeting.Equals(SINGLE_OPPONENT) || commandParams.GetSkill().targeting.Equals(MULTIPLE_OPPONENTS);
        }
        else
        {
            throw new System.Exception("SelectOneTargetState couldn't infer offensive intention of skill/item.");
        }
        targetSelector.Show(UnitUtil.GetUnitsFor(commandParams.GetSubject(), base.owner.allUnits, offensive));
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
        targetSelector.OnTargetClicked -= Next;
    }
}