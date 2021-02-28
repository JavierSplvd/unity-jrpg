using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

public class UnitUtilTest
{
    [Test]
    public void SetDebuffDontAddDuplicates()
    {
        UnitSO unit = TestUtil.CreateUnit();

        UnitUtil.SetDebuff(unit, Debuff.BURN);
        UnitUtil.SetDebuff(unit, Debuff.BURN);

        Assert.That(unit.currentDebuffs.Length == 1);
        Assert.That(unit.currentDebuffs.ToArray()[0].Equals(Debuff.BURN));
    }

    [Test]
    public void SetDebuffAddValues()
    {
        UnitSO unit = TestUtil.CreateUnit();

        UnitUtil.SetDebuff(unit, Debuff.BURN);
        UnitUtil.SetDebuff(unit, Debuff.STUN);

        Assert.That(unit.currentDebuffs.Length == 2);
        Assert.That(unit.currentDebuffs.Contains(Debuff.BURN));
        Assert.That(unit.currentDebuffs.Contains(Debuff.STUN));
    }

    [Test]
    public void RemoveDebuffDeletesElement()
    {
        UnitSO unit = TestUtil.CreateUnit();
        UnitUtil.SetDebuff(unit, Debuff.BURN);
        UnitUtil.SetDebuff(unit, Debuff.STUN);

        UnitUtil.RemoveDebuff(unit, Debuff.BURN);

        Assert.That(unit.currentDebuffs.Length == 1);
        Assert.That(!unit.currentDebuffs.Contains(Debuff.BURN));
        Assert.That(unit.currentDebuffs.Contains(Debuff.STUN));
    }

    [Test]
    public void RemoveDebuffDoesNothingWhenTypeNotContained()
    {
        UnitSO unit = TestUtil.CreateUnit();
        UnitUtil.SetDebuff(unit, Debuff.BURN);
        UnitUtil.SetDebuff(unit, Debuff.STUN);

        UnitUtil.RemoveDebuff(unit, Debuff.POISON);

        Assert.That(unit.currentDebuffs.Length == 2);
        Assert.That(unit.currentDebuffs.Contains(Debuff.BURN));
        Assert.That(unit.currentDebuffs.Contains(Debuff.STUN));
    }

    [Test]
    public void RemoveDebuffAwareWhenArrayItsNull()
    {
        UnitSO unit = TestUtil.CreateUnit();

        UnitUtil.RemoveDebuff(unit, Debuff.POISON);

        Assert.That(unit.currentDebuffs.Length == 0);
    }

    [Test]
    public void ChargeTurnPoints_FunctionOfSpeed()
    {
        UnitSO unit = TestUtil.CreateUnit();
        UnitSO[] allUnits = new UnitSO[] {unit};
        unit.maxTurnCount = 100f;
        unit.currentTurnCount = 0f;
        unit.speed = 10;

        UnitUtil.ChargeTurnPointsAllUnits(allUnits, 1);

        Assert.AreEqual(10, unit.currentTurnCount);
    }

    [Test]
    public void ChargeTurnPoints_ReducedWhenStun()
    {
        UnitSO unit = TestUtil.CreateUnit();
        UnitSO[] allUnits = new UnitSO[] {unit};
        unit.maxTurnCount = 100f;
        unit.currentTurnCount = 0f;
        unit.speed = 50;
        unit.currentDebuffs = new Debuff[1] {Debuff.STUN};

        UnitUtil.ChargeTurnPointsAllUnits(allUnits, 1);

        Assert.AreEqual(10, unit.currentTurnCount);
    }

    [Test]
    public void GetSumOfHP_forEachController()
    {
        UnitSO playerUnitA = TestUtil.CreateUnit();
        playerUnitA.currentHP = 50;
        playerUnitA.controller = Controller.PLAYER;
        UnitSO playerUnitB = TestUtil.CreateUnit();
        playerUnitB.currentHP = 60;
        playerUnitB.controller = Controller.PLAYER;
        UnitSO aiUnitC = TestUtil.CreateUnit();
        aiUnitC.currentHP = 90;
        aiUnitC.controller = Controller.AI;

        UnitSO[] allUnits = new UnitSO[] {playerUnitA, playerUnitB, aiUnitC};
        float countPlayer = UnitUtil.GetSumOfHP(allUnits, Controller.PLAYER);
        float countAI = UnitUtil.GetSumOfHP(allUnits, Controller.AI);

        Assert.AreEqual(110, countPlayer);
        Assert.AreEqual(90, countAI);
    }
}
