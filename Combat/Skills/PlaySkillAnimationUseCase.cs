using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PlaySkillAnimationUseCase : UseCase<object>
{
    public static List<SkillAnimation> components;
    private string unitId;
    private SkillAnimationName name;
    
    public PlaySkillAnimationUseCase(string unitId, SkillAnimationName name)
    {
        this.unitId = unitId;
        this.name = name;
    }

    public object Execute()
    {
        if(components == null)
        {
            components = GameObject.FindObjectsOfType<SkillAnimation>().ToList();
        }
        GetSkillAnimation(components, unitId).Play(name);
        return null;
    }

    public SkillAnimation GetSkillAnimation(List<SkillAnimation> listComponents, string id)
    {
        var sa = listComponents.FirstOrDefault<SkillAnimation>(it => it.GetUnitId().Equals(id));
        if(sa == null)
        {
            throw new System.Exception("PlaySkillAnimationUseCase couldnt find any SkillAnimation. id=" + id);
        }
        return sa;
    }
}