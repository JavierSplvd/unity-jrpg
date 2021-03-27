using NUnit.Framework;

public class HealUseCaseTest {
    [Test]
    public void ShouldHealUsingFormula()
    {
        var cp = new CommandParams(
            TestUtil.CreateUnit(),
            TestUtil.CreateUnit(),
            null,
            TestUtil.CreateHealSkill()
        );
        var result = new HealUseCase(cp).Execute();

        Assert.AreEqual(4.4f, result);
    }

    [Test]
    public void GivenDeadUnit_ShouldNotHeal()
    {
        UnitSO alive = TestUtil.CreateUnit();
        alive.finalMaxHP = 200;
        alive.currentHP = 100;
        UnitSO dead = TestUtil.CreateUnit();
        dead.finalMaxHP = 200;
        dead.currentHP = 0;
        dead.currentStatusEffect = new StatusEffect[] {StatusEffect.DEATH};

        var cp = new CommandParams(
            alive,
            new UnitSO[] {alive, dead},
            null,
            TestUtil.CreateHealSkill()
        );
        var result = new HealUseCase(cp).Execute();

        Assert.Greater(alive.currentHP, 100);
        Assert.AreEqual(dead.currentHP, 0);
    }

}