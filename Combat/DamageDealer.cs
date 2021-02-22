public class DamageDealer {
   public static readonly DamageDealer _obj = new DamageDealer();

   DamageDealer() {}

   public void Damage(CommandParams commandParams)
   {
       // Modifier should take into account resistances/weaknesess
       float modifier = 1;
       float power = commandParams.GetSkill().power;
       // Decide between physical and magical attack+defense
       float attack = commandParams.GetSubject().attack;
       float defense = commandParams.GetTarget().defense;
       float level = commandParams.GetSubject().level;

       float formulaRes = ((2 * level /5 + 2) * (power / 50) * (attack / defense) + 2) * modifier;

       commandParams.GetTarget().currentHP -= formulaRes;
   }
}
