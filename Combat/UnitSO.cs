using UnityEngine;

[CreateAssetMenu(fileName = "UnitSO", menuName = "BattleSystem/UnitSO", order = 0)]
public class UnitSO : ScriptableObject {
    public string unitName;
    public float level;
    public float attack;
    public float maxHP;
    public float currentHP;

    public GameObject prefab;
}