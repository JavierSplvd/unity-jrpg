using UnityEngine;

[CreateAssetMenu(fileName = "BasicAttackSkillSO", menuName = "BattleSystem/BasicAttackSkillSO", order = 0)]
public class BasicAttackSkillSO : SkillSO {
    public UnitSO owner, target;

    public override void Initialize(GameObject obj) {
        
    }

    public override void Execute()
    {
        float valueA = (owner.level * 2 + 10) / 250;
        float valueB = owner.attack / target.defense;
        float randomness = Random.Range(0.9f, 1f);
        target.currentHP = power * valueA * valueB;
    }
}