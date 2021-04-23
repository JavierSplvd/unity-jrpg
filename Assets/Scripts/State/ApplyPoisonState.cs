using System.Linq;
using static StatusEffect;

public class ApplyPosionState : State<BattleSystem>
{
    private UnityUtilities.Countdown timer;
    private readonly float POISON_PERCENTAGE = 0.04f;

    public ApplyPosionState(BattleSystem owner) : base(owner)
    {
        if(base.owner.allUnits.ToList()
            .Select(it => it.currentStatusEffect.Contains(POISON)).ToArray().Length == 0)
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
            owner.ChangeState(new UpkeepState(base.owner));
        }
    }

    public override void OnStateExit()
    {
        base.owner.allUnits.ToList().ForEach(it => {
            if(it.currentStatusEffect.Contains(POISON))
            {
                new DamagePercentageUseCase(it, POISON_PERCENTAGE).Execute();
            }
        });
    }

    public override void OnStateEnter()
    {

    }
}