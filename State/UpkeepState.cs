using UnityEngine;
using static Controller;

public class UpkeepState : State<BattleSystem>
{
    public UpkeepState(BattleSystem owner) : base(owner)
    {

    }

    public override void Tick()
    {
        UnitUtil.ChargeTurnPointsAllUnits(base.owner.allUnits, Time.fixedDeltaTime);
        UnitSO tentativeActiveUnit = owner.GetActiveUnit();
        if(tentativeActiveUnit && tentativeActiveUnit.controller.Equals(PLAYER))
        {
            owner.ChangeState(new UnitUpkeepState(owner, tentativeActiveUnit));
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