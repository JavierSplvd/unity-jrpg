using UnityEngine;
using NUnit.Framework;
using static Debuff;
using System.Linq;

public class CleanUpStateTest
{
    [Test]
    public void OnStateEnter_ApplyDamageBurn()
    {
        RandomWrapper.test = true;
        
        UnitSO unit = TestUtil.CreateUnit();
        unit.maxHP = 100f;
        unit.currentHP = 100f;
        unit.currentDebuffs = new Debuff[1] {BURN};
        BattleSystem battleSystem = TestUtil.Create<BattleSystem>();
        battleSystem.allUnits = new UnitSO[1] {unit};
        State<BattleSystem> cleanUp = new CleanUpState(battleSystem);

        float atStart = unit.currentHP;
        cleanUp.OnStateEnter();

        Assert.That(atStart > unit.currentHP);
        Assert.AreEqual(100f, atStart);
        Assert.AreEqual(97f, unit.currentHP);
    }
}
