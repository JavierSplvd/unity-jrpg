using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlaySkillAnimationUseCaseTest {
    [Test]
    public void GivenSkillAnimationList_FindById()
    {
        var list = new List<SkillAnimation>();
        var go = new GameObject();
        go.AddComponent<SkillAnimation>();
        var sa = go.GetComponent<SkillAnimation>();
        sa.SetUnitId("target");
        list.Add(go.GetComponent<SkillAnimation>());
        PlaySkillAnimationUseCase useCase = new PlaySkillAnimationUseCase("target", SkillAnimationName.EMPTY);

        var result = useCase.GetSkillAnimation(list, "target");

        Assert.AreEqual(sa, result);
    }

    [Test]
    public void GivenSkillAnimationList_ThrowExceptionWhenThereIsNoMatch()
    {
        var list = new List<SkillAnimation>();
        var go = new GameObject();
        go.AddComponent<SkillAnimation>();
        var sa = go.GetComponent<SkillAnimation>();
        sa.SetUnitId("target");
        list.Add(go.GetComponent<SkillAnimation>());
        PlaySkillAnimationUseCase useCase = new PlaySkillAnimationUseCase("target", SkillAnimationName.EMPTY);

        Assert.Throws<System.Exception>(() => {
            var result = useCase.GetSkillAnimation(list, "missing");
        });
    }

}