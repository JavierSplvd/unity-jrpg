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
}
