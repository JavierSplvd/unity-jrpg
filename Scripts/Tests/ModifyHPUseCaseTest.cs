using NUnit.Framework;
using System.Linq;

public class ModifyHPUseCaseTest {
    [Test]
    public void ShouldClampHPMaxValue() {
        UnitSO unit = TestUtil.CreateUnit();
        float initialHP = unit.currentHP;

        var result = new ModifyHPUseCase(unit, 10).Execute();

        Assert.AreEqual(unit.currentHP, initialHP);
    }

    [Test]
    public void ShouldChangeHP() {
        UnitSO unit = TestUtil.CreateUnit();
        float initialHP = unit.currentHP;

        var result = new ModifyHPUseCase(unit, - initialHP * 0.5f).Execute();

        Assert.AreEqual(unit.currentHP, initialHP - initialHP * 0.5f);
    }

    [Test]
    public void WhenHpIsZero_ApplyDeath() {
        UnitSO unit = TestUtil.CreateUnit();
        float initialHP = unit.currentHP;

        var result = new ModifyHPUseCase(unit, - 2 * initialHP).Execute();

        Assert.AreEqual(unit.currentHP, 0);
        Assert.IsTrue(unit.currentStatusEffect.Contains(StatusEffect.DEATH));
    }

    
}