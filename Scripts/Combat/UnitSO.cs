using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitSO", menuName = "BattleSystem/UnitSO", order = 0)]
public class UnitSO : ScriptableObject {
    [Header("Name")]
    public string unitId;
    public string unitName;
    [Header("Level and exp")]
    public float level;
    [Header("Equipment")]
    public EquipmentSO[] equipment;
    [Header("Base stats")]
    public float baseAttack = 100;
    public float baseDefense = 100;
    public float baseMagicAttack = 100;
    public float baseMagicDefense = 100;
    public float baseSpeed = 100;
    public float baseMaxHP = 100;
    public float baseMaxMP = 100;
    [Header("Stats for the level")]
    public float levelAttack;
    public float levelDefense;
    public float levelMagicAttack;
    public float levelMagicDefense;
    public float levelSpeed;
    public float levelMaxHP;
    public float levelMaxMP;
    [Header("Stats after level+equipment")]
    public float finalAttack;
    public float finalDefense;
    public float finalMagicAttack;
    public float finalMagicDefense;
    public float finalSpeed;
    public float finalMaxHP;
    public float finalMaxMP;
    [Header("Current values")]
    public float currentHP;
    public float currentMP;
    public float maxTurnCount = 100;
    public float currentTurnCount;
    public StatusEffect[] currentStatusEffect;
    [Header("Status Effect Weakness")]
    public float stunWeakness;
    public float poisonWeakness;
    public float burnWeakness;
    public float freezeWeakness;
    public float cryingWeakness;
    public float hungryWeakness;
    public float forgetWeakness;

    [Header("Other")]
    public Controller controller;

    public SkillSO[] skills;
    [Header("Graphics")]
    public GameObject prefab;
    public Sprite sprite;
}