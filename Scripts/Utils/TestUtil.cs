using System;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class TestUtil {
    private class BattleSystemProxy : BattleSystem {
        public override void ChangeState(State<BattleSystem> newState) {

        }
    }

    public static T CreateUnity<T>() {
        GameObject go = new GameObject();
        if (typeof(T) == typeof(Animator)) {
            go.AddComponent<Animator>();
        } else if (typeof(T) == typeof(Image)) {
            go.AddComponent<Image>();
        }
        return go.GetComponent<T>();
    }

    public static SkillSO CreateHealSkill() {
        SkillSO skill = ScriptableObject.CreateInstance<HealSkillSO>();
        skill.power = 100;
        skill.isMagical = true;
        skill.targeting = SkillTarget.SINGLE_ALLY;
        return skill;
    }

    public static SkillSO CreateDamageSkill() {
        SkillSO skill = ScriptableObject.CreateInstance<BasicAttackSkillSO>();
        skill.power = 100;
        skill.isMagical = false;
        skill.targeting = SkillTarget.SINGLE_ALLY;
        skill.element = Element.NORMAL;
        return skill;
    }

    public static T Create<T>() {
        return (T) FormatterServices.GetUninitializedObject(typeof(T));
    }

    public static UnitSO CreateUnit() {
        UnitSO unit = ScriptableObject.CreateInstance<UnitSO>();
        unit.currentStatusEffect = new StatusEffect[0] { };
        unit.finalAttack = 100;
        unit.finalDefense = 100;
        unit.finalMagicAttack = 100;
        unit.finalMagicDefense = 100;
        unit.currentHP = 100;
        unit.finalMaxHP = 100;
        unit.level = 50;
        unit.elementalWeakness = new SerializableDictionary<Element, float>() { { Element.NORMAL, 100 }, { Element.FIRE, 99 }, { Element.ANIMAL, 101 } };
        return unit;
    }

    public static BattleSystem CreateBattleSystem() {
        return new BattleSystemProxy();
    }

}