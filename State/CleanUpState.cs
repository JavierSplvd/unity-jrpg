using UnityEngine;

public class CleanUpState : State<BattleSystem>
{
    private UnityUtilities.Countdown timer;

    public CleanUpState(BattleSystem owner) : base(owner)
    {
        timer = new UnityUtilities.Countdown(false, 0.3f);
    }

    public override void Tick()
    {
        if(timer.Progress())
        {
            owner.ChangeState(new UpkeepState(base.owner));
        }
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }
}