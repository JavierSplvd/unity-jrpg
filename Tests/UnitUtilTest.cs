using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

public class UnitUtilTest
{
    [Test]
    public void SetDebuffAddsTypeToUnitAndItsUnique()
    {
        UnitSO unit = GetUnit();

        UnitUtil.SetDebuff(unit, Debuff.BURN);
        UnitUtil.SetDebuff(unit, Debuff.BURN);

        Assert.That(unit.currentDebuffs.Count == 1);
        Assert.That(unit.currentDebuffs.ToArray()[0].Equals(Debuff.BURN));
    }

    private UnitSO GetUnit()
    {
        return ScriptableObject.CreateInstance<UnitSO>();
    }
}
