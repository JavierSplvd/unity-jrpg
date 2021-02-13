using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] TeamSO allies;
    [SerializeField] TeamSO enemies;
    [SerializeField] Transform alliesTransform;
    [SerializeField] Transform enemiesTransform;

    [SerializeField] GameObject originalBattleHUD;

    [SerializeField] State<Battle> currentState;
    public string currentStateName;

    private UnitSO ally;
    private UnitSO enemy;

    public Text dialogueText;

    // The turn order goes like this:
    // Start: this is the start of the battle, only once per battle
    // repeat Upkeep, Unit, CleanUp,
    // Select target: only when some ability is used that requires a target.
    // if one team is out of health Won/Lost state
    void Start() 
    {
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
        ally = allies.units[0];
        enemy = enemies.units[0];

        GameObject allyGo = Instantiate(ally.prefab, alliesTransform.GetChild(0));
        GameObject allyHUD = Instantiate(originalBattleHUD, alliesTransform.GetChild(0));
        allyHUD.GetComponent<BattleHUD>().SetHUD(ally);

        GameObject enemyGo = Instantiate(enemy.prefab, enemiesTransform);
        GameObject enemyHUD = Instantiate(originalBattleHUD, enemiesTransform);
        enemyHUD.GetComponent<BattleHUD>().SetHUD(enemy);
        
        dialogueText.text = "Prepare for battle!";

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
}
