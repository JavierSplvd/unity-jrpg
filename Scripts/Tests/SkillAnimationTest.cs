using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using static SkillAnimationName;

public class SkillAnimationTest
{
    [Test]
    public void AtStart_ImageIsNotVisible()
    {
        var go = new GameObject();
        go.AddComponent<Animator>();
        go.AddComponent<Image>();
        var skillAnimation = go.AddComponent<SkillAnimation>();
        
        skillAnimation.Awake();

        Assert.That(!skillAnimation.GetImage().enabled);
    }

    [Test]
    public void WhenAnimationIsPlayed_ImageVisible()
    {
        var go = new GameObject();
        go.AddComponent<Animator>();
        go.AddComponent<Image>();
        var skillAnimation = go.AddComponent<SkillAnimation>();
        
        skillAnimation.Awake();
        skillAnimation.Play(SKILL_ATTACK);

        Assert.That(skillAnimation.GetImage().enabled);
    }
}
