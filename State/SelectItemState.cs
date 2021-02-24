using UnityEngine;

public class SelectItemState : State<BattleSystem>
{
    private InventorySO inventory;
    private BattleItemSelector itemSelector;
    private CommandParams commandParams;
    public SelectItemState(BattleSystem owner, InventorySO inventory, CommandParams commandParams) : base(owner)
    {
        this.commandParams = commandParams;
        this.inventory = inventory;
        itemSelector = GameObject.FindObjectOfType<BattleItemSelector>().GetComponent<BattleItemSelector>();
    }
    public override void Tick()
    {
        
    }

    public override void OnStateEnter()
    {
        itemSelector.Show(inventory.items);
    }

    public override void OnStateExit()
    {
        itemSelector.Hide();
    }
}