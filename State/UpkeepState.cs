using UnityEngine;

public class UpkeepState : State<Battle>
{
    public UpkeepState(Battle owner) : base(owner)
    {

    }

    public override void Tick()
    {
        owner.ChargeUnitTurn();
        UnitSO u = owner.GetActiveUnit();
        if(u)
        {
            owner.ChangeState(new UnitSelectActionState(owner, u));
        }
    }

    public override void OnStateEnter() 
    {
        base.owner.UpdateDialogueText("Upkeep...");
    }

    public override void OnStateExit()
    {

    }
}