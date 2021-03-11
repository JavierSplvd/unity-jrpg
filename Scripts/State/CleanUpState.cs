using System.Linq;
using static Debuff;
using UnityEngine;

public class CleanUpState : State<BattleSystem>
{
    private UnityUtilities.Countdown timer;
    private readonly float BURN_PERCENTAGE = 0.03f;
    private readonly float POISON_PERCENTAGE = 0.04f;
    private readonly float HUNGRY_PERCENTAGE = 0.03f;

    public CleanUpState(BattleSystem owner) : base(owner)
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
        // Apply poison, burn and hungry:
        base.owner.allUnits.ToList().ForEach(it => {
            if(it.currentDebuffs.Contains(BURN))
            {
                DamageDealer._obj.DamagePercentage(it, BURN_PERCENTAGE);
            }
            if(it.currentDebuffs.Contains(POISON))
            {
                DamageDealer._obj.DamagePercentage(it, POISON_PERCENTAGE);
            }
            if(it.currentDebuffs.Contains(HUNGRY))
            {
                DamageDealer._obj.DamagePercentage(it, HUNGRY_PERCENTAGE);
            }
        });
    }

    public override void OnStateExit()
    {

    }
}