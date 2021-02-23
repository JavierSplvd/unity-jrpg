using System.Collections.Generic;
using System.Linq;
using static Controller;
using Assets.Scripts.Utils;

public class AIState : State<BattleSystem>
{
    private UnitSO activeUnit;

    public AIState(BattleSystem owner, UnitSO tentativeActiveUnit) : base(owner)
    {
        this.activeUnit = tentativeActiveUnit;
    }

    public override void Tick()
    {
        SkillSO randomSkill = RandomUtil.NextItem(activeUnit.skills);
        UnitSO randomTarget = pickRandomTarget();
        
        CommandParams commandParams = new CommandParams(
            activeUnit,
            randomTarget,
            null,
            randomSkill
        );

        base.owner.ChangeState(new AttackState(base.owner, commandParams));
    }

    private UnitSO pickRandomTarget()
    {
        Controller targetController = PLAYER;
        List<UnitSO> targets = base.owner.allUnits.ToList().Where(it => it.controller.Equals(targetController)).ToList();
        return RandomUtil.NextItem<UnitSO>(targets);
    }

    public override void OnStateEnter()
    {

    }

    public override void OnStateExit()
    {

    }
}