using NUnit.Framework;

public class HealFlatUseCaseTest {
    [Test]
    public void ShouldHealPower() {
        var cp = new CommandParams(
            TestUtil.CreateUnit(),
            TestUtil.CreateUnit(),
            null,
            TestUtil.CreateHealSkill()
        );
        float result = new DamageFlatUseCase(cp).Execute();

        Assert.AreEqual(100f, result);
    }

    [Test]
    public void GivenDeadUnit_ShouldNotHeal() {
        UnitSO alive = TestUtil.CreateUnit();
        alive.maxHP = 200;
        alive.currentHP = 100;
        UnitSO dead = TestUtil.CreateUnit();
        dead.maxHP = 200;
        dead.currentHP = 0;
        dead.currentStatusEffect = new StatusEffect[] { StatusEffect.DEATH };

        var cp = new CommandParams(
            alive,
            new UnitSO[] { alive, dead },
            null,
            TestUtil.CreateHealSkill()
        );
        float result = new DamageFlatUseCase(cp).Execute();

        Assert.Greater(alive.currentHP, 100);
        Assert.AreEqual(dead.currentHP, 0);
    }

}