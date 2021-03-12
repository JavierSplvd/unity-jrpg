using System.Linq;

public class AttackState : State<BattleSystem>
{
    private CommandParams commandParams;
    private UnityUtilities.Countdown timer;
   
    public delegate void UpdateStatus(string[] ids);
    public static event UpdateStatus OnUpdateStatus;
 
    public AttackState(BattleSystem owner, CommandParams commandParams) : base(owner)
    {
        this.commandParams = commandParams;
        timer = new UnityUtilities.Countdown(false, 0.3f);
    }

    public override void Tick()
    {
        if(timer.Progress())
        {
            if(commandParams.GetSkill() != null)
            {
                ExecuteSkill();
                // Consume mana/energy
                UnitUtil.SubstractMana(commandParams.GetSubject(), commandParams.GetSkill());
            }
            else if(commandParams.GetItem() != null)
            {
                ExecuteItem();
                // Consume item
                UnitUtil.ConsumeItem(owner.GetInventory(), commandParams.GetItem());
            }
            
            
            owner.ChangeState(new CleanUpState(base.owner));
        }
    }

    private void ExecuteSkill()
    {
        commandParams.GetSkill().Initialize(commandParams);
        commandParams.GetSkill().Execute();
    }

    private void ExecuteItem()
    {
        commandParams.GetItem().Execute(commandParams);
    }

    public override void OnStateEnter()
    {
        string subject = commandParams.GetSubject()?.unitName;
        string targets = "all";
        if(commandParams.GetTargets().Length == 1)
        {
            targets = commandParams.GetTargets()[0].unitName;
        }
        string item = commandParams.GetItem()?.itemName;
        string skill = commandParams.GetSkill()?.skillName;
        base.owner.UpdateDialogueText(subject + " performs " + skill + " to " + targets);
    }

    public override void OnStateExit()
    {
        if(OnUpdateStatus != null)
        {
            OnUpdateStatus(commandParams.GetTargets().ToList().Select(it => it.unitId).ToArray());
        }
    }
}