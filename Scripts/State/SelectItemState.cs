using System.Linq;
using UnityEngine;
using static SkillTarget;

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
        itemSelector.OnItemClicked += ItemSelected;
        itemSelector.Show(inventory.items);
    }

    private void ItemSelected(string i)
    {
        Debug.Log("ItemSelected");
        // Get the item by id
        ItemSO item = inventory.items.ToList().First(it => it.itemId.Equals(i));
        // Create wrapper object with the subject, item and skill related to the item
        CommandParams newParams = new CommandParams(commandParams.GetSubject(), item, null);
        // Go to the next state: select one target or attack
        if(item.targeting.Equals(SINGLE_OPPONENT) || item.targeting.Equals(SINGLE_ALLY))
        {
            base.owner.ChangeState(new SelectOneTargetState(base.owner, newParams));
        }
        else if (item.targeting.Equals(SELF))
        {
            commandParams = new CommandParams(commandParams.GetSubject(), commandParams.GetSubject(), item, null);
            base.owner.ChangeState(new AttackState(base.owner, commandParams));
        }
    }

    public override void OnStateExit()
    {
        itemSelector.OnItemClicked -= ItemSelected;
        itemSelector.Hide();
    }
}