using UnityEngine;

[CreateAssetMenu(fileName = "UnitSO", menuName = "BattleSystem/UnitSO", order = 0)]
public class UnitSO : ScriptableObject {
    public string unitName;
    public float level;
    public float attack;
    public float defense;
    public float magicAttack;
    public float magicDefense;
    public float speed;
    public float maxHP;
    public float currentHP;
    public float maxMP;
    public float currentMP;
    public float maxTurnCount = 100;
    public float currentTurnCount;


    public SkillSO[] skills;

    public GameObject prefab;
    public Sprite sprite;
}