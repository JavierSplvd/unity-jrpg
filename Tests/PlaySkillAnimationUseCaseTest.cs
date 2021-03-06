using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;
using System.Collections.Generic;

public class PlaySkillAnimationUseCaseTest {
    [Test]
    public void GivenSkillAnimationList_FindById()
    {
        PlaySkillAnimationUseCase useCase = new PlaySkillAnimationUseCase();
        var list = new List<SkillAnimation>();
        var go = new GameObject();
        go.AddComponent<SkillAnimation>();
        var sa = go.GetComponent<SkillAnimation>();
        sa.SetUnitId("target");
        list.Add(go.GetComponent<SkillAnimation>());

        var result = useCase.GetSkillAnimation(list, "target");

        Assert.AreEqual(sa, result);
    }

    [Test]
    public void GivenSkillAnimationList_ThrowExceptionWhenThereIsNoMatch()
    {
        PlaySkillAnimationUseCase useCase = new PlaySkillAnimationUseCase();
        var list = new List<SkillAnimation>();
        var go = new GameObject();
        go.AddComponent<SkillAnimation>();
        var sa = go.GetComponent<SkillAnimation>();
        sa.SetUnitId("target");
        list.Add(go.GetComponent<SkillAnimation>());

        Assert.Throws<System.Exception>(() => {
            var result = useCase.GetSkillAnimation(list, "missing");
        });
    }

}