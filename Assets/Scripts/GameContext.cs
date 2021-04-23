using UnityEngine;

public class GameContext : MonoBehaviour {
    private static GameContext _instance;

    public static GameContext Instance { get { return _instance; } }

    [SerializeField] public NumiInput input;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void Update() {
        if(NumiInput._instance.f1) {
            new StartBattleUseCase().Execute();
        }
        if(NumiInput._instance.f2) {
            new StopBattleUseCase().Execute();
        }
    }
}