using UnityEngine;

public abstract class ItemSO : ScriptableObject {
    public string itemId;
    public string itemName;
    public int quantity;
    public int buyValue, sellValue;
    public SkillTarget targeting;
    public abstract void Execute(CommandParams commandParams);
}