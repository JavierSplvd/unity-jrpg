using UnityEngine;
using static Controller;

public class UpkeepState : State<BattleSystem>
{
    public UpkeepState(BattleSystem owner) : base(owner)
    {

    }

    public override void Tick()
    {
        owner.ChargeUnitTurn();
        UnitSO tentativeActiveUnit = owner.GetActiveUnit();
        if(tentativeActiveUnit && tentativeActiveUnit.controller.Equals(PLAYER))
        {
            owner.ChangeState(new UnitSelectActionState(owner, tentativeActiveUnit));
        }
        else if (tentativeActiveUnit && tentativeActiveUnit.controller.Equals(AI))
        {
            owner.ChangeState(new AIState(owner, tentativeActiveUnit));
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