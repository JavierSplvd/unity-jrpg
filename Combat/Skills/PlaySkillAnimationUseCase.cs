using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlaySkillAnimationUseCase : UseCase
{
    public static List<SkillAnimation> components;

    public void Execute(params object[] list)
    {
        var id = (string) list[0];
        var name = (SkillAnimationName) list[1];
        if(components == null)
        {
            components = GameObject.FindObjectsOfType<SkillAnimation>().ToList();
        }
        GetSkillAnimation(components, id).Play(name);
    }

    public SkillAnimation GetSkillAnimation(List<SkillAnimation> list, string id)
    {
        var sa = list.FirstOrDefault<SkillAnimation>(it => it.GetUnitId().Equals(id));
        if(sa == null)
        {
            throw new System.Exception("PlaySkillAnimationUseCase couldnt find any SkillAnimation.");
        }
        return sa;
    }
}