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
        var sa = components.FirstOrDefault<SkillAnimation>(it => it.unitId.Equals(id));
        sa?.Play(name);
        if(sa == null)
        {
            Debug.LogWarning("PlaySkillAnimationUseCase couldnt find any SkillAnimation.");
        }
    }
}