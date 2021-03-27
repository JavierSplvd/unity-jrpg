using System.Linq;
using UnityEngine;
using static Controller;
using static StatusEffect;
using System;

public class UnitUtil {
    public static UnitSO[] GetUnitsFor(UnitSO subject, UnitSO[] units, bool offensive) {
        Controller subjectController = subject.controller;
        Controller opposingController = subject.controller.Equals(PLAYER) ? AI : PLAYER;
        Controller targetController = offensive? opposingController : subjectController;
        return units.ToList().Where(it => it.controller.Equals(targetController)).ToArray();
    }

    public static UnitSO[] GetAliveFriends(UnitSO[] units, Controller controller) {
        return units.ToList().Where(it => it.controller.Equals(controller) && !it.currentStatusEffect.Contains(StatusEffect.DEATH)).ToArray();
    }

    public static UnitSO[] GetAliveOpponents(UnitSO[] units, Controller controller) {
        return units.ToList().Where(it => !it.controller.Equals(controller) && !it.currentStatusEffect.Contains(StatusEffect.DEATH)).ToArray();
    }

    public static float GetSumOfHP(UnitSO[] units, Controller controller) {
        float count = 0;
        units.ToList().ForEach(it => {
            if (it.controller.Equals(controller)) {
                count += it.currentHP;
            }
        });
        return count;
    }

    internal static void ConsumeItem(InventorySO inventory, ItemSO item) {
        inventory.items.ToList().First(it => it.itemId.Equals(item.itemId)).quantity -= 1;
    }

    public static void SubstractMana(UnitSO subject, SkillSO skill) {
        // Debug.Log(subject.unitName +"/"+ subject.currentMP.ToString() +"/"+ skill.manaCost.ToString());
        subject.currentMP = Mathf.Clamp(subject.currentMP - skill.manaCost, 0, subject.levelMaxMP);
    }

    public static void ResetUnits(UnitSO[] allUnits) {
        allUnits.ToList().ForEach(it => {
            it.unitId = it.unitName + it.GetHashCode();
            it.currentHP = it.finalMaxHP;
            it.currentMP = it.finalMaxMP;
            it.currentTurnCount = 0;
        });
    }

    public static void SetStatusEffect(UnitSO target, StatusEffect type) {
        if (target.currentStatusEffect == null) {
            target.currentStatusEffect = new StatusEffect[1] { type };
        } else {
            var asList = target.currentStatusEffect.ToList();
            asList.Add(type);
            target.currentStatusEffect = asList.Distinct().ToArray();
        }
    }

    public static void RemoveStatusEffect(UnitSO target, StatusEffect type) {
        if (target.currentStatusEffect == null) {
            target.currentStatusEffect = new StatusEffect[0];
            return;
        }
        int index = Array.IndexOf(target.currentStatusEffect, type);
        var asList = target.currentStatusEffect.ToList();
        asList.Remove(type);
        target.currentStatusEffect = asList.ToArray();
    }

    public static void ScaleStatsByLevel(UnitSO[] allUnits) {
        allUnits.ToList().ForEach(it => {
            float multi = it.level / 30 + 1;
            it.levelMaxHP = (int) (it.baseMaxHP * multi);
            it.levelMaxMP = (int) (it.baseMaxMP * multi);
            it.levelAttack = (int) (it.baseAttack * multi);
            it.levelDefense = (int) (it.baseDefense * multi);
            it.levelMagicAttack = (int) (it.baseMagicAttack * multi);
            it.levelMagicDefense = (int) (it.baseMagicDefense * multi);
            it.levelSpeed = (int) (it.baseSpeed * multi);
        });
    }

    public static void ApplyStatsEquipment(UnitSO[] allUnits) {
        allUnits.ToList().ForEach(unit => {
            unit.finalAttack = unit.levelAttack;
            unit.finalDefense = unit.levelDefense;
            unit.finalMagicAttack = unit.levelMagicAttack;
            unit.finalMagicDefense = unit.levelMagicDefense;
            unit.finalMaxHP = unit.levelMaxHP;
            unit.finalMaxMP = unit.levelMaxMP;
            unit.finalSpeed = unit.levelSpeed;
        });

        allUnits.ToList().ForEach(unit => unit.equipment.ToList().ForEach(equipm => {
            unit.finalAttack = unit.levelAttack + equipm.bonusAttack;
            unit.finalDefense = unit.levelDefense + equipm.bonusDefense;
            unit.finalMagicAttack = unit.levelMagicAttack + equipm.bonusMagicAttack;
            unit.finalMagicDefense = unit.levelMagicDefense + equipm.bonusMagicDefense;
            unit.finalMaxHP = unit.levelMaxHP + equipm.bonusMaxHP;
            unit.finalMaxMP = unit.levelMaxMP + equipm.bonusMaxMP;
            unit.finalSpeed = unit.levelSpeed + equipm.bonusSpeed;
        }));
    }

    public static float GetWeakness(StatusEffect type, UnitSO unit) {
        switch (type) {
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

    public static void ChargeTurnPointsAllUnits(UnitSO[] allUnits, float deltaTime) {
        allUnits.ToList().ForEach(it => {
            if (it.currentStatusEffect.Contains(StatusEffect.STUN)) {
                it.currentTurnCount += deltaTime * it.finalSpeed * 0.5f;
            } else if (it.currentStatusEffect.Contains(StatusEffect.DEATH)) {
                // Do not gain
            } else {
                it.currentTurnCount += deltaTime * it.finalSpeed;
            }
        });
    }
}