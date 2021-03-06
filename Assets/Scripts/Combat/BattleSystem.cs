using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] TeamSO allyTeam;
    [SerializeField] TeamSO enemyTeam;
    [SerializeField] public UnitSO[] allUnits;
    [SerializeField] public GameObject[] HUDForAlliedUnits;
    [SerializeField] public GameObject[] HUDForEnemyUnits;
    [SerializeField] public InventorySO playerInventory;
    [SerializeField] public GameObject winLoseElement;

    [SerializeField] State<BattleSystem> currentState;
    public string currentStateName;

    private UnitSO ally;
    private UnitSO enemy;

    public Text dialogueText;
    public BattleCommandSelector commandSelector;
    private BattleTargetSelector targetSelector;
    private BattleItemSelector itemSelector;
    // The turn order goes like this:
    // Start: this is the start of the battle, only once per battle
    // repeat Upkeep, UnitSelectAction, UnitSelectTarget, AttackPhase, CleanUp,
    // Select target: only when some skill is used that requires a target.
    // if one team is out of health Won/Lost state
    void Start() 
    {
        winLoseElement.SetActive(false);
        commandSelector = GameObject.FindObjectOfType<BattleCommandSelector>().GetComponent<BattleCommandSelector>();
        targetSelector = GameObject.FindObjectOfType<BattleTargetSelector>().GetComponent<BattleTargetSelector>();
        itemSelector = GameObject.FindObjectOfType<BattleItemSelector>().GetComponent<BattleItemSelector>();
        currentState = new StartState(this);
        SetupBattle();
        HideCommandSelector();
        targetSelector.Hide();
        itemSelector.Hide();
    }

    void FixedUpdate()
    {
        currentStateName = currentState.ToString();
        currentState.Tick();
    }

    void SetupBattle()
    {
        ally = allyTeam.units[0];
        enemy = enemyTeam.units[0];

        for (int i = 0; i < allyTeam.units.Length; i++)
        {
            HUDForAlliedUnits[i].GetComponent<IBattleHUD>().SetUnit(allyTeam.units[i]);
        }
        for (int i = allyTeam.units.Length; i < HUDForAlliedUnits.Length; i++)
        {
            HUDForAlliedUnits[i].gameObject.SetActive(false);
        }

        HUDForEnemyUnits[0].GetComponent<IBattleHUD>().SetUnit(enemy);
        
        dialogueText.text = "Prepare for battle!";

        allUnits = allyTeam.units.Concat(enemyTeam.units).ToArray();
        // Reset units and place ids
        UnitUtil.ScaleStatsByLevel(allUnits);
        UnitUtil.ApplyStatsEquipment(allUnits);
        UnitUtil.ResetUnits(allUnits);
    }

    public virtual void ChangeState(State<BattleSystem> newState)
    {
        currentState.OnStateExit();
        currentState = newState;
        newState.OnStateEnter();
    }

    public void UpdateDialogueText(string newText)
    {
        dialogueText.text = newText;
    }

    internal UnitSO GetActiveUnit()
    {
        foreach(UnitSO u in allUnits)
        {
            u.isActive = false;
            if(u.currentTurnCount >= 100)
            {
                u.isActive = true;
                u.currentTurnCount -= 100;
                return u;
            }
        } 
        return null;
    }

    internal void UpdateCommandSelector(UnitSO activeUnit)
    {
        commandSelector.UpdateCommandSelector(activeUnit);
    }
    internal void ShowCommandSelector(float x)
    {
        commandSelector.ShowCommandSelector(x);
    }
    internal void HideCommandSelector()
    {
        commandSelector.HideCommandSelector();
    }
    internal InventorySO GetInventory() => playerInventory;

    public void ShowWinLoseMessage(string text)
    {
        winLoseElement.SetActive(true);
        winLoseElement.transform.GetChild(0).GetComponent<Text>().text = text;
    }
}
