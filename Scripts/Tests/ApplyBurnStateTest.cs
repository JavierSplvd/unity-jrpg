using NUnit.Framework;
using static StatusEffect;

public class ApplyBurnStateTest
{
    [Test]
    public void OnStateEnter_ApplyDamageBurn()
    {
        RandomWrapper.test = true;
        
        UnitSO unit = TestUtil.CreateUnit();
        unit.maxHP = 100f;
        unit.currentHP = 100f;
        unit.currentStatusEffect = new StatusEffect[1] {BURN};
        BattleSystem battleSystem = TestUtil.Create<BattleSystem>();
        battleSystem.allUnits = new UnitSO[1] {unit};
        State<BattleSystem> cleanUp = new ApplyBurnState(battleSystem);

        float atStart = unit.currentHP;
        cleanUp.OnStateExit();

        Assert.That(atStart > unit.currentHP);
        Assert.AreEqual(100f, atStart);
        Assert.AreEqual(97f, unit.currentHP);
    }
}
