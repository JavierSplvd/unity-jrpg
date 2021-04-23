using UnityEngine;

[CreateAssetMenu(fileName = "TeamSO", menuName = "BattleSystem/TeamSO", order = 0)]
public class TeamSO : ScriptableObject {
    public string teamName;
    public UnitSO[] units;
}