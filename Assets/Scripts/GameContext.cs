using UnityEngine;

public class GameContext : MonoBehaviour {
    private static GameContext _instance;
    private BattleSM battleSM;
    public static GameContext Instance { get { return _instance; } }

    [SerializeField] public NumiInput input;

    private void Awake() {
        battleSM = new BattleSM();

        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void Update() {
        battleSM.Update();
    }
}