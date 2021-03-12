using UnityEngine;

[CreateAssetMenu(fileName = "ItemHealingSO", menuName = "BattleSystem/ItemHealingSO", order = 0)]
public class ItemHealingSO : ItemSO {
    public float power;
    public override void Execute(CommandParams commandParams)
    {
        new DamageFlatUseCase(commandParams).Execute();
    }
    
}