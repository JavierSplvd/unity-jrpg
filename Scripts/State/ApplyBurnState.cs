using System.Linq;
using static StatusEffect;

public class ApplyBurnState : State<BattleSystem>
{
    private UnityUtilities.Countdown timer;
    private readonly float BURN_PERCENTAGE = 0.03f;

    public ApplyBurnState(BattleSystem owner) : base(owner)
    {
        if(base.owner.allUnits.ToList()
            .Select(it => it.currentStatusEffect.Contains(BURN)).ToArray().Length == 0)
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
            owner.ChangeState(new ApplyHungryState(base.owner));
        }
    }

    public override void OnStateExit()
    {
        base.owner.allUnits.ToList().ForEach(it => {
            if(it.currentStatusEffect.Contains(BURN))
            {
                new DamagePercentageUseCase(it, BURN_PERCENTAGE).Execute();
            }
        });
    }

    public override void OnStateEnter()
    {

    }
}