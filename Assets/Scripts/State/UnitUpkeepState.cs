using System.Collections.Generic;
using System.Linq;
using static StatusEffect;

public class UnitUpkeepState : State<BattleSystem> // rename to RemoveStunState???
{
    private UnitSO activeUnit;

    public UnitUpkeepState(BattleSystem owner, UnitSO activeUnit) : base(owner)
    {
        this.activeUnit = activeUnit;
    }

    public override void Tick()
    {
        
    }

    public override void OnStateEnter() 
    {
        // remove stun
        List<StatusEffect> asList = activeUnit.currentStatusEffect.ToList();
        asList.Remove(STUN);
        activeUnit.currentStatusEffect = asList.ToArray();
        //
        owner.ChangeState(new UnitSelectActionState(owner, activeUnit));
    }

    public override void OnStateExit()
    {

    }
}