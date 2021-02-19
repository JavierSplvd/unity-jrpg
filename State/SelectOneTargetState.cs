using UnityEngine;

public class SelectOneTargetState : State<Battle>
{
    private CommandParams commandParams;
    private BattleTargetSelector targetSelector;
    private UnitSO target;
    public SelectOneTargetState(Battle owner, CommandParams commandParams) : base(owner)
    {
        this.commandParams = commandParams;
        targetSelector = GameObject.FindObjectOfType<BattleTargetSelector>().GetComponent<BattleTargetSelector>();
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        targetSelector.Show(base.owner.allUnits);
    }

    public override void OnStateExit()
    {
        CommandParams newParams = new CommandParams(commandParams.GetSubject(), target, null, commandParams.GetSkill());
        targetSelector.Hide();
    }
}