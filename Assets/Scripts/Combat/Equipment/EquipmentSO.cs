using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentSO", menuName = "BattleSystem/EquipmentSO", order = 0)]
public class EquipmentSO : ScriptableObject {
    public string itemName;
    public Sprite image;
    public EquipmentType type;

    [Header("Bonus flat stats")]
    public int bonusAttack;
    public int bonusDefense;
    public int bonusMagicAttack;
    public int bonusMagicDefense;
    public int bonusSpeed;
    public int bonusMaxHP;
    public int bonusMaxMP;
    
}