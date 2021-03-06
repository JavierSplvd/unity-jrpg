using UnityEngine;
using System.Linq;
using System;

public class DamageDealer {
   public static readonly DamageDealer _obj = new DamageDealer();

   DamageDealer() {}

   public float Damage(CommandParams commandParams)
   {
       float total = 0;
       commandParams.GetTargets().ToList().ForEach(it => {
            total += DamageOne(commandParams.GetSubject(), it, commandParams.GetSkill());
       });
       
       return total;
   }

    internal void DamageFlat(CommandParams commandParams, float power)
    {
        commandParams.GetTargets().ToList().ForEach(it => {
            it.currentHP = Mathf.Clamp(
                it.currentHP - power * RandomWrapper.Range(0.2f),
                0,
                it.maxHP
            );
            DamageLogger.Add(it.unitId, (int) - power);    
        });
    }

    public void DamagePercentage(UnitSO target, float percentage)
    {
        float damage =  - target.maxHP * percentage * RandomWrapper.Range(0.2f);
        target.currentHP = Mathf.Clamp(
            target.currentHP + damage,
            0,
            target.maxHP
        );
        DamageLogger.Add(target.unitId, (int) damage);
    }

    private float DamageOne(UnitSO subject, UnitSO target, SkillSO skill)
   {
        // Modifier should take into account resistances/weaknesess
        float modifier = 1;
        float power = skill.power;
        // Decide between physical and magical attack+defense
        bool isMagic = skill.isMagical;
        float attack = isMagic? subject.magicAttack : subject.attack;
        float defense = isMagic? subject.magicDefense : target.defense;
        float level = subject.level;

        float formulaRes = ((2 * level /5 + 2) * (power / 50) * (attack / defense) + 2) * modifier * RandomWrapper.Range(0.2f);

        target.currentHP = Mathf.Clamp(
            target.currentHP - formulaRes,
            0,
            target.maxHP
        );
        DamageLogger.Add(target.unitId, (int) - formulaRes);
        return formulaRes;
   }
}
