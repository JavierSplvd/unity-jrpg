using UnityEngine;

public class StartState : State<Battle>
{
    public StartState(Battle owner) : base(owner)
    {

    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {
        owner.ChangeState(new UpkeepState(base.owner));
    }
}