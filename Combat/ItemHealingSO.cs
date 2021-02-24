using UnityEngine;

[CreateAssetMenu(fileName = "ItemHealingSO", menuName = "BattleSystem/ItemHealingSO", order = 0)]
public class ItemHealingSO : ItemSO {
    public float power;
    public override void Execute(CommandParams commandParams)
    {
        HealDealer._obj.HealFlat(commandParams, power);
    }
    
}