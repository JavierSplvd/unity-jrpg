using UnityEngine.SceneManagement;

public class StartBattleUseCase: UseCase<bool>
{
    public bool Execute()
    {
        SceneManager.LoadScene("BattleTest", LoadSceneMode.Additive);
        return true;
    }
}
