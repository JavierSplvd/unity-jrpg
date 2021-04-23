using System.Collections.Generic;
using System.Linq;
using static Controller;
using Assets.Scripts.Utils;
using static SkillTarget;

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
        UnitSO[] randomTargets = new UnitSO[1] {pickRandomPlayerTarget()};
        switch (randomSkill.targeting)
        {
            case SINGLE_OPPONENT:
                randomTargets = new UnitSO[1] {pickRandomPlayerTarget()};
                break;
            case SINGLE_ALLY:
                randomTargets = new UnitSO[1] {activeUnit};
                break;
            case SELF:
                randomTargets = new UnitSO[1] {activeUnit};
                break;
            case MULTIPLE_ALLIES:
                randomTargets = UnitUtil.GetAliveFriends(base.owner.allUnits, AI);
                break;
            case MULTIPLE_OPPONENTS:
                randomTargets = UnitUtil.GetAliveOpponents(base.owner.allUnits, AI);
                break;
            default:
                throw new System.Exception("Exhaust enum at AIState.Tick()");
        }
        
        
        CommandParams commandParams = new CommandParams(
            activeUnit,
            randomTargets,
            null,
            randomSkill
        );

        base.owner.ChangeState(new AttackState(base.owner, commandParams));
    }

    private UnitSO pickRandomPlayerTarget()
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