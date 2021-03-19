using UnityEngine;
using System.Linq;
using static Controller;
using static StatusEffect;
using System;

public class UnitUtil {
    public static UnitSO[] GetUnitsFor(UnitSO subject, UnitSO[] units, bool offensive)
    {
        Controller subjectController = subject.controller;
        Controller opposingController = subject.controller.Equals(PLAYER)? AI : PLAYER;
        Controller targetController = offensive? opposingController : subjectController;
        return units.ToList().Where(it => it.controller.Equals(targetController)).ToArray();
    }

    public static UnitSO[] GetFriends(UnitSO[] units, Controller controller)
    {
        return units.ToList().Where(it => it.controller.Equals(controller)).ToArray();
    }

    public static UnitSO[] GetOpponents(UnitSO[] units, Controller controller)
    {
        return units.ToList().Where(it => !it.controller.Equals(controller)).ToArray();
    }

    public static float GetSumOfHP(UnitSO[] units, Controller controller)
    {
        float count = 0;
        units.ToList().ForEach(it => {
            if(it.controller.Equals(controller))
            {
                count +=it.currentHP;
            }
        });
        return count;
    }

    internal static void ConsumeItem(InventorySO inventory, ItemSO item)
    {
        inventory.items.ToList().First(it => it.itemId.Equals(item.itemId)).quantity -= 1;
    }

    public static void SubstractMana(UnitSO subject, SkillSO skill)
    {
        // Debug.Log(subject.unitName +"/"+ subject.currentMP.ToString() +"/"+ skill.manaCost.ToString());
        subject.currentMP = Mathf.Clamp(subject.currentMP - skill.manaCost, 0, subject.maxMP);
    }

    public static void ResetUnits(UnitSO[] allUnits)
    {
        allUnits.ToList().ForEach(it => {
            it.unitId = it.unitName + it.GetHashCode();
            it.currentHP = it.maxHP;
            it.currentMP = it.maxMP;
            it.currentTurnCount = 0;
        });
    }

    public static void SetStatusEffect(UnitSO target, StatusEffect type)
    {
        if(target.currentStatusEffect == null)
        {
            target.currentStatusEffect = new StatusEffect[1] {type};
        }
        else
        {
            var asList = target.currentStatusEffect.ToList();
            asList.Add(type);
            target.currentStatusEffect = asList.Distinct().ToArray();
        }
    }

    public static void RemoveStatusEffect(UnitSO target, StatusEffect type)
    {
        if(target.currentStatusEffect == null)
        {
            target.currentStatusEffect = new StatusEffect[0];
            return;
        }
        int index = Array.IndexOf(target.currentStatusEffect, type);
        var asList = target.currentStatusEffect.ToList();
        asList.Remove(type);
        target.currentStatusEffect = asList.ToArray();
    }

    public static void LevelScaling(UnitSO[] allUnits)
    {
        allUnits.ToList().ForEach(it => {
            float multi = it.level / 30 + 1;
            it.maxHP = (int) (it.baseMaxHP * multi);
            it.maxMP = (int) (it.baseMaxMP * multi);
            it.attack = (int) (it.baseAttack * multi);
            it.defense = (int) (it.baseDefense * multi);
            it.magicAttack = (int) (it.baseMagicAttack * multi);
            it.magicDefense = (int) (it.baseMagicDefense * multi);
            it.speed = (int) (it.baseSpeed * multi);
        });
    }

    public static float GetWeakness(StatusEffect type, UnitSO unit)
    {
        switch(type)
        {
            case STUN:
                return unit.stunWeakness;
            case POISON:
                return unit.poisonWeakness;
            case BURN:
                return unit.burnWeakness;
            case FREEZE:
                return unit.freezeWeakness;
            case CRYING:
                return unit.cryingWeakness;
            case HUNGRY:
                return unit.hungryWeakness;
            case FORGET:
                return unit.forgetWeakness;
        }
        return 0;
    }
        
    public static void ChargeTurnPointsAllUnits(UnitSO[] allUnits, float deltaTime)
    {
        allUnits.ToList().ForEach(it => {
            if(it.currentStatusEffect.Contains(StatusEffect.STUN))
            {
                it.currentTurnCount += deltaTime * it.speed * 0.5f;
            }
            else
            {
                it.currentTurnCount += deltaTime * it.speed;
            }
        });
    }
}