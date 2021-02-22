public class AIState : State<BattleSystem>
{
    private UnitSO activeUnit;

    public AIState(BattleSystem owner, UnitSO tentativeActiveUnit) : base(owner)
    {
        this.activeUnit = tentativeActiveUnit;
    }

    public override void Tick()
    {
        base.owner.ChangeState(new CleanUpState(base.owner));
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }
}