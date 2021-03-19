using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization;
using System;

public class TestUtil
{
    private class BattleSystemProxy : BattleSystem
    {
        public override void ChangeState(State<BattleSystem> newState)
        {
            
        }
    }

    public static T CreateUnity<T>() 
    {
        GameObject go = new GameObject();
        if(typeof(T) == typeof(Animator))
        {
            go.AddComponent<Animator>();
        }
        else if(typeof(T) == typeof(Image))
        {
            go.AddComponent<Image>();
        }
        return go.GetComponent<T>();
    }

    public static SkillSO CreateHealSkill()
    {
        SkillSO skill = ScriptableObject.CreateInstance<HealSkillSO>();
        skill.power = 100;
        skill.isMagical = true;
        return skill;
    }

    public static T Create<T>()
    {
        return (T) FormatterServices.GetUninitializedObject(typeof(T));
    }

    public static UnitSO CreateUnit()
    {
        UnitSO unit = ScriptableObject.CreateInstance<UnitSO>();
        unit.currentStatusEffect = new StatusEffect[0] {};
        unit.magicAttack = 100;
        unit.level = 1;
        return unit;
    }

    public static BattleSystem CreateBattleSystem()
    {
        return new BattleSystemProxy();
    }

}