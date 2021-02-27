using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

public class UnitUtilTest
{
    [Test]
    public void SetDebuffDontAddDuplicates()
    {
        UnitSO unit = CreateUnit();

        UnitUtil.SetDebuff(unit, Debuff.BURN);
        UnitUtil.SetDebuff(unit, Debuff.BURN);

        Assert.That(unit.currentDebuffs.Length == 1);
        Assert.That(unit.currentDebuffs.ToArray()[0].Equals(Debuff.BURN));
    }

    [Test]
    public void SetDebuffAddValues()
    {
        UnitSO unit = CreateUnit();

        UnitUtil.SetDebuff(unit, Debuff.BURN);
        UnitUtil.SetDebuff(unit, Debuff.STUN);

        Assert.That(unit.currentDebuffs.Length == 2);
        Assert.That(unit.currentDebuffs.Contains(Debuff.BURN));
        Assert.That(unit.currentDebuffs.Contains(Debuff.STUN));
    }

    [Test]
    public void RemoveDebuffDeletesElement()
    {
        UnitSO unit = CreateUnit();
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
        UnitSO unit = CreateUnit();
        UnitUtil.SetDebuff(unit, Debuff.BURN);
        UnitUtil.SetDebuff(unit, Debuff.STUN);

        UnitUtil.RemoveDebuff(unit, Debuff.POISON);

        Assert.That(unit.currentDebuffs.Length == 2);
        Assert.That(unit.currentDebuffs.Contains(Debuff.BURN));
        Assert.That(unit.currentDebuffs.Contains(Debuff.STUN));
    }

    private UnitSO CreateUnit()
    {
        return ScriptableObject.CreateInstance<UnitSO>();
    }
}
