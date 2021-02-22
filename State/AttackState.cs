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
            owner.ChangeState(new CleanUpState(base.owner));
        }
    }

    public override void OnStateEnter()
    {
        string subject = commandParams.GetSubject()?.unitName;
        string target = commandParams.GetTarget()?.unitName;
        string item = commandParams.GetItem()?.itemName;
        string skill = commandParams.GetSkill()?.skillName;
        base.owner.UpdateDialogueText(subject + " performs " + skill + " to " + target);
    }

    public override void OnStateExit()
    {

    }
}