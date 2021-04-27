public class BattleSM {
    private bool onBattle = false;

    public void Update() {
        if (NumiInput._instance.f1 && !onBattle) {
            onBattle = true;
            new StartBattleUseCase().Execute();
        }
        if (NumiInput._instance.f2 && onBattle) {
            onBattle = false;
            new StopBattleUseCase().Execute();
        }
    }
}