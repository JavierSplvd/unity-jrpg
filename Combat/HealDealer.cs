using UnityEngine;

public class HealDealer {
   public static readonly HealDealer _obj = new HealDealer();

   HealDealer() {}

   public float Heal(CommandParams commandParams)
   {
       // Modifier should take into account resistances/weaknesess
       float modifier = 1;
       float power = commandParams.GetSkill().power;
       // Decide between physical and magical attack+defense
       bool isMagic = commandParams.GetSkill().isMagical;
       float attack = isMagic? commandParams.GetSubject().magicAttack : commandParams.GetSubject().attack;
       float level = commandParams.GetSubject().level;

       float formulaRes = ((2 * level /5 + 2) * (power / 50) * (attack / 200) + 2) * modifier;

       commandParams.GetTarget().currentHP = Mathf.Clamp(
           formulaRes + commandParams.GetTarget().currentHP,
           0,
           commandParams.GetTarget().maxHP
        );
        return formulaRes;
   }
}
