using UnityEngine;

public class ActiveUnitState : State<Battle>
{
    private UnitSO activeUnit;

    public ActiveUnitState(Battle owner, UnitSO activeUnit) : base(owner)
    {
        this.activeUnit = activeUnit;
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter() 
    {
        base.owner.UpdateDialogueText("It's " + activeUnit.unitName + " turn.");
    }

    public override void OnStateExit()
    {

    }
}