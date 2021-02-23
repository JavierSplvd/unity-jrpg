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

    [SerializeField] State<BattleSystem> currentState;
    public string currentStateName;

    private UnitSO ally;
    private UnitSO enemy;

    public Text dialogueText;
    public BattleCommandSelector commandSelector;
    private BattleTargetSelector targetSelector;

    // The turn order goes like this:
    // Start: this is the start of the battle, only once per battle
    // repeat Upkeep, UnitSelectAction, UnitSelectTarget, AttackPhase, CleanUp,
    // Select target: only when some skill is used that requires a target.
    // if one team is out of health Won/Lost state
    void Start() 
    {
        commandSelector = GameObject.FindObjectOfType<BattleCommandSelector>().GetComponent<BattleCommandSelector>();
        targetSelector = GameObject.FindObjectOfType<BattleTargetSelector>().GetComponent<BattleTargetSelector>();
        currentState = new StartState(this);
        SetupBattle();
        HideCommandSelector();
        targetSelector.Hide();
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

        HUDForAlliedUnits[0].GetComponent<IBattleHUD>().SetUnit(ally);
        HUDForEnemyUnits[0].GetComponent<IBattleHUD>().SetUnit(enemy);
        
        dialogueText.text = "Prepare for battle!";

        allUnits = allyTeam.units.Concat(enemyTeam.units).ToArray();
        // Reset units and place ids
        allUnits.ToList().ForEach(it => {
            it.unitId = it.unitName + it.GetHashCode();
            it.currentHP = it.maxHP;
            it.currentMP = it.maxMP;
            it.currentTurnCount = 0;
        });
    }

    public void ChangeState(State<BattleSystem> newState)
    {
        currentState.OnStateExit();
        currentState = newState;
        newState.OnStateEnter();
    }

    public void UpdateDialogueText(string newText)
    {
        dialogueText.text = newText;
    }

    internal void ChargeUnitTurn()
    {
        foreach(UnitSO u in allUnits)
        {
            u.currentTurnCount += Time.fixedDeltaTime * u.speed;
        }
    }

    internal UnitSO GetActiveUnit()
    {
        foreach(UnitSO u in allUnits)
        {
            if(u.currentTurnCount >= 100)
            {
                u.currentTurnCount -= 100;
                return u;
            }
        } 
        return null;
    }

    internal void UpdateCommandSelector(SkillSO[] abilities)
    {
        commandSelector.UpdateCommandSelector(abilities);
    }
    internal void ShowCommandSelector(float x)
    {
        commandSelector.ShowCommandSelector(x);
    }
    internal void HideCommandSelector()
    {
        commandSelector.HideCommandSelector();
    }
}
