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

    public override void OnStateExit()
    {
        // Apply poison, burn and hungry:
        base.owner.allUnits.ToList().ForEach(it => {
            if(it.currentDebuffs.Contains(BURN))
            {
                new DamagePercentageUseCase(it, BURN_PERCENTAGE).Execute();
            }
            if(it.currentDebuffs.Contains(POISON))
            {
                new DamagePercentageUseCase(it, POISON_PERCENTAGE).Execute();
            }
            if(it.currentDebuffs.Contains(HUNGRY))
            {
                new DamagePercentageUseCase(it, HUNGRY_PERCENTAGE).Execute();
            }
        });
    }

    public override void OnStateEnter()
    {

    }
}