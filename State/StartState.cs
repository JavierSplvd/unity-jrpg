using UnityEngine;

public class StartState : State<Battle>
{
    private UnityUtilities.Countdown timer;
    public StartState(Battle owner) : base(owner)
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