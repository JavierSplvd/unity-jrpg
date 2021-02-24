using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "BattleSystem/ItemSO", order = 0)]
public class ItemSO : ScriptableObject {
    public string itemName;
    public int quantity;
    public int buyValue, sellValue;
    public SkillSO skillRelated;
}