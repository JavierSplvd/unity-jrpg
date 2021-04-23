using UnityEngine;

[CreateAssetMenu(fileName = "InventorySO", menuName = "BattleSystem/InventorySO", order = 0)]
public class InventorySO : ScriptableObject {
    public Controller owner;
    public ItemSO[] items;
}