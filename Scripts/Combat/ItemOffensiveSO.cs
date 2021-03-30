using System.Linq;
using UnityEngine;
using static StatusEffect;

[CreateAssetMenu(fileName = "ItemOffensiveSO", menuName = "BattleSystem/ItemOffensiveSO", order = 0)]
public class ItemOffensiveSO : ItemSO {
    public float power;
    public Element element = Element.NORMAL;

    // 0 => 0% of inflict that status. 100 => 100% chance of inflicting that.
    public float stun; // unable to gain turn points
    public float poison; // Lose HP every turn
    public float burn; // Lose HP every turn
    public float freeze; // Slow turn
    public float crying; // Low accuracy
    public float hungry; // Lose HP every turn
    public float forget; // Unable to do 2, 3 and 4 skill

    struct StatusEffectChance {
        public StatusEffect type;
        public float chance;

        internal StatusEffectChance(StatusEffect type, float chance)
        {
            this.type = type;
            this.chance = chance;
        }
    }

    public override void Execute(CommandParams commandParams)
    {
        StatusEffectChance[] chances = new StatusEffectChance[] {
            new StatusEffectChance(STUN, stun),
            new StatusEffectChance(POISON, poison),
            new StatusEffectChance(BURN, burn),
            new StatusEffectChance(FREEZE, freeze),
            new StatusEffectChance(CRYING, crying),
            new StatusEffectChance(HUNGRY, hungry),
            new StatusEffectChance(FORGET, forget),
        };
        commandParams.GetTargets().ToList().ForEach(target => {
            chances.ToList().ForEach(it => {
                float weakness = UnitUtil.GetWeakness(it.type, target);
                bool hit = Random.Range(0f, 100f) <= it.chance + weakness;
                if(hit)
                {
                    UnitUtil.SetStatusEffect(target, it.type);
                }
                // Debug.Log(hit + "/" + it.type);
            });
        });
        
        new DamageFlatUseCase(commandParams).Execute();
    }
}