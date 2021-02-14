using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] TeamSO allyTeam;
    [SerializeField] TeamSO enemyTeam;
    [SerializeField] Transform alliesTransform;
    [SerializeField] Transform enemiesTransform;
    [SerializeField] UnitSO[] allUnits;
    [SerializeField] GameObject originalBattleHUD;

    [SerializeField] State<Battle> currentState;
    public string currentStateName;

    private UnitSO ally;
    private UnitSO enemy;

    public Text dialogueText;
    private BattleCommandSelector commandSelector;

    // The turn order goes like this:
    // Start: this is the start of the battle, only once per battle
    // repeat Upkeep, Unit, CleanUp,
    // Select target: only when some ability is used that requires a target.
    // if one team is out of health Won/Lost state
    void Start() 
    {
        commandSelector = GameObject.FindObjectOfType<BattleCommandSelector>().GetComponent<BattleCommandSelector>();
        currentState = new StartState(this);
        SetupBattle();
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

        GameObject allyGo = Instantiate(ally.prefab, alliesTransform.GetChild(0).GetChild(0));
        GameObject allyHUD = Instantiate(originalBattleHUD, alliesTransform.GetChild(0));
        allyHUD.GetComponent<BattleHUD>().SetHUD(ally);

        GameObject enemyGo = Instantiate(enemy.prefab, enemiesTransform);
        GameObject enemyHUD = Instantiate(originalBattleHUD, enemiesTransform);
        enemyHUD.GetComponent<BattleHUD>().SetHUD(enemy);
        
        dialogueText.text = "Prepare for battle!";

        allUnits = allyTeam.units.Concat(enemyTeam.units).ToArray();

        Destroy(originalBattleHUD);
    }

    public void ChangeState(State<Battle> newState)
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

    internal void UpdateCommandSelector(AbilitySO[] abilities)
    {
        commandSelector.UpdateCommandSelector(abilities);
    }
}
