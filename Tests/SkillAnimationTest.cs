using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using static SkillAnimationName;

public class SkillAnimationTest
{
    [Test]
    public void AtStart_ImageIsNotVisible()
    {
        SkillAnimation sa = new SkillAnimation(
            TestUtil.Create<Animator>(),
            TestUtil.Create<Image>()
        );

        Assert.That(!sa.GetImage().enabled);
    }

    [Test]
    public void WhenAnimationIsPlayed_ImageVisible()
    {
        SkillAnimation sa = new SkillAnimation(
            TestUtil.Create<Animator>(),
            TestUtil.Create<Image>()
        );

        sa.Play(SKILL_ATTACK);

        Assert.That(sa.GetImage().enabled);
    }
}
