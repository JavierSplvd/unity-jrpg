using System.Linq;
using static StatusEffect;

public class ApplyHungryState : State<BattleSystem>
{
    private UnityUtilities.Countdown timer;
    private readonly float HUNGRY_PERCENTAGE = 0.03f;

    public ApplyHungryState(BattleSystem owner) : base(owner)
    {
        if(base.owner.allUnits.ToList()
            .Select(it => it.currentStatusEffect.Contains(HUNGRY)).ToArray().Length == 0)
        {
            timer = new UnityUtilities.Countdown(false, 0f);
        }
        else
        {
            timer = new UnityUtilities.Countdown(false, 0.3f);
        }
    }

    public override void Tick()
    {
        if(timer.Progress())
        {
            owner.ChangeState(new ApplyPosionState(base.owner));
        }
    }

    public override void OnStateExit()
    {
        // Apply poison, burn and hungry:
        base.owner.allUnits.ToList().ForEach(it => {
            if(it.currentStatusEffect.Contains(HUNGRY))
            {
                new DamagePercentageUseCase(it, HUNGRY_PERCENTAGE).Execute();
            }
        });
    }

    public override void OnStateEnter()
    {

    }
}