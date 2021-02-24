using UnityEngine;

public class AttackState : State<BattleSystem>
{
    private CommandParams commandParams;
    private UnityUtilities.Countdown timer;
    public AttackState(BattleSystem owner, CommandParams commandParams) : base(owner)
    {
        this.commandParams = commandParams;
        timer = new UnityUtilities.Countdown(false, 0.3f);
    }

    public override void Tick()
    {
        if(timer.Progress())
        {
            commandParams.GetSkill().Initialize(commandParams);
            commandParams.GetSkill().Execute();
            
            owner.ChangeState(new CleanUpState(base.owner));
        }
    }

    public override void OnStateEnter()
    {
        string subject = commandParams.GetSubject()?.unitName;
        string targets = "all";
        if(commandParams.GetTargets().Length == 1)
        {
            targets = commandParams.GetTargets()[0].unitName;
        }
        string item = commandParams.GetItem()?.itemName;
        string skill = commandParams.GetSkill()?.skillName;
        base.owner.UpdateDialogueText(subject + " performs " + skill + " to " + targets);
    }

    public override void OnStateExit()
    {

    }
}