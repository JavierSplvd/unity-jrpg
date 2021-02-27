using System.Linq;
using UnityEngine;
using static Debuff;

[CreateAssetMenu(fileName = "ItemOffensiveSO", menuName = "BattleSystem/ItemOffensiveSO", order = 0)]
public class ItemOffensiveSO : ItemSO {
    public float power;

    // 0 => 0% of inflict that status. 100 => 100% chance of inflicting that.
    public float stun; // unable to gain turn points
    public float poison; // Lose HP every turn
    public float burn; // Lose HP every turn
    public float freeze; // Slow turn
    public float crying; // Low accuracy
    public float hungry; // Lose HP every turn
    public float forget; // Unable to do 2, 3 and 4 skill

    struct DebuffChance {
        public Debuff type;
        public float chance;

        internal DebuffChance(Debuff type, float chance)
        {
            this.type = type;
            this.chance = chance;
        }
    }

    public override void Execute(CommandParams commandParams)
    {
        DebuffChance[] chances = new DebuffChance[] {
            new DebuffChance(STUN, stun),
            new DebuffChance(POISON, poison),
            new DebuffChance(BURN, burn),
            new DebuffChance(FREEZE, freeze),
            new DebuffChance(CRYING, crying),
            new DebuffChance(HUNGRY, hungry),
            new DebuffChance(FORGET, forget),
        };
        commandParams.GetTargets().ToList().ForEach(target => {
            chances.ToList().ForEach(it => {
                float weakness = UnitUtil.GetWeakness(it.type, target);
                bool hit = Random.Range(0f, 100f) <= it.chance + weakness;
                if(hit)
                {
                    UnitUtil.SetDebuff(target, it.type);
                }
                Debug.Log(hit + "/" + it.type);
            });
        });
        

        DamageDealer._obj.DamageFlat(commandParams, power);
    }
}