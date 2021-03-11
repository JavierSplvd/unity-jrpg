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
        float playerHP = UnitUtil.GetSumOfHP(base.owner.allUnits, Controller.PLAYER);
        float aiHP = UnitUtil.GetSumOfHP(base.owner.allUnits, Controller.AI);
        if(aiHP == 0)
        {
            base.owner.ChangeState(new WinState(base.owner));
        }
        else if(playerHP == 0)
        {
            base.owner.ChangeState(new DefeatState(base.owner));
        }
    }

    public override void OnStateExit()
    {

    }
}