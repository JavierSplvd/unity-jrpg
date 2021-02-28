using System.Collections.Generic;
using System.Linq;
using static Debuff;

public class UnitUpkeepState : State<BattleSystem>
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
        List<Debuff> asList = activeUnit.currentDebuffs.ToList();
        asList.Remove(STUN);
        activeUnit.currentDebuffs = asList.ToArray();
        owner.ChangeState(new UnitSelectActionState(owner, activeUnit));
    }

    public override void OnStateExit()
    {

    }
}