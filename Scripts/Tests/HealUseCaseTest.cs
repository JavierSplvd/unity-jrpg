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

}