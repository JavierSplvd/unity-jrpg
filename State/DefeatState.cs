using UnityEngine;

public class DefeatState : State<BattleSystem>
{
    public DefeatState(BattleSystem owner) : base(owner)
    {

    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        base.owner.UpdateDialogueText("Defeat...");
        base.owner.ShowWinLoseMessage("Experience...");
    }

    public override void OnStateExit()
    {

    }
}