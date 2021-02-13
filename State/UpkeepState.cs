using UnityEngine;

public class UpkeepState : State<Battle>
{
    public UpkeepState(Battle owner) : base(owner)
    {

    }

    public override void Tick()
    {

    }

    public override void OnStateEnter() 
    {
        base.owner.UpdateDialogueText("Upkeep...");
    }

    public override void OnStateExit()
    {

    }
}