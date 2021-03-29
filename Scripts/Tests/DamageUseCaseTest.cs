using NUnit.Framework;
using UnityEngine;
using System.Linq;

public class DamageUseCaseTest {

    [SetUp]
    public void setup()
    {
        RandomWrapper.test = true;
    }
    [Test]
    public void GivenElementalWeakness_DoMoreDamage() {
        UnitSO target = TestUtil.CreateUnit();
        target.elementalWeakness[Element.NORMAL] = 200f;
        var cp = new CommandParams(
            TestUtil.CreateUnit(),
            target,
            null,
            TestUtil.CreateDamageSkill()
        );
        float result = new DamageUseCase(cp).Execute();

        Assert.AreEqual(92f, result);
    }

    [Test]
    public void GivenNoElemental_DoRegularDamage() {
        var cp = new CommandParams(
            TestUtil.CreateUnit(),
            TestUtil.CreateUnit(),
            null,
            TestUtil.CreateDamageSkill()
        );
        float result = new DamageUseCase(cp).Execute();

        Assert.AreEqual(46f, result);
    }

    [Test]
    public void GivenElementalResistance_DoLessDamage() {
        UnitSO target = TestUtil.CreateUnit();
        target.elementalWeakness[Element.NORMAL] = 50;
        var cp = new CommandParams(
            TestUtil.CreateUnit(),
            target,
            null,
            TestUtil.CreateDamageSkill()
        );
        float result = new DamageUseCase(cp).Execute();

        Assert.AreEqual(23f, result);
    }

}