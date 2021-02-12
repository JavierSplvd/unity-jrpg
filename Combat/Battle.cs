using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] TeamSO allies;
    [SerializeField] TeamSO enemies;
    [SerializeField] Transform alliesTransform;
    [SerializeField] Transform enemiesTransform;

    [SerializeField] GameObject prefabHUD;

    [SerializeField] State<Battle> currentState;
    public string currentStateName;

    private UnitSO ally;
    private UnitSO enemy;

    public Text dialogueText;

    // The turn order goes like this:
    // Start, 
    // repeat Upkeep, Unit, CleanUp, 
    // if one team is out of health Won/Lost
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

        GameObject allyGo = Instantiate(ally.prefab, alliesTransform);
        GameObject allyHUD = Instantiate(prefabHUD, alliesTransform);
        allyHUD.GetComponent<BattleHUD>().SetHUD(ally);

        GameObject enemyGo = Instantiate(enemy.prefab, enemiesTransform);
        GameObject enemyHUD = Instantiate(prefabHUD, enemiesTransform);
        enemyHUD.GetComponent<BattleHUD>().SetHUD(enemy);
        
        dialogueText.text = "Prepare for battle!";
    }

    public void ChangeState(State<Battle> newState)
    {
        currentState = newState;
    }

}
