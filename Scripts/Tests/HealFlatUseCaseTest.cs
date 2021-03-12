using NUnit.Framework;

public class HealFlatUseCaseTest {
    [Test]
    public void ShouldHealPower()
    {
        var cp = new CommandParams(
            TestUtil.CreateUnit(),
            TestUtil.CreateUnit(),
            null,
            TestUtil.CreateHealSkill()
        );
        float result = new DamageFlatUseCase(cp).Execute();

        Assert.AreEqual(100f, result);
    }

}