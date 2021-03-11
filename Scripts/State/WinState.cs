using UnityEngine;

public class WinState : State<BattleSystem>
{
    public WinState(BattleSystem owner) : base(owner)
    {

    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        base.owner.UpdateDialogueText("Victory!");
        base.owner.ShowWinLoseMessage("Hero wins!");
    }

    public override void OnStateExit()
    {

    }
}