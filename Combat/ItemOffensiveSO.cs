using UnityEngine;

[CreateAssetMenu(fileName = "ItemOffensiveSO", menuName = "BattleSystem/ItemOffensiveSO", order = 0)]
public class ItemOffensiveSO : ItemSO {
    public float power;
    public override void Execute(CommandParams commandParams)
    {
        DamageDealer._obj.DamageFlat(commandParams, power);
    }
}