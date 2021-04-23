using UnityEngine.SceneManagement;

public class StopBattleUseCase: UseCase<bool>
{
    public bool Execute()
    {
        SceneManager.UnloadSceneAsync("BattleTest");
        return true;
    }
}
