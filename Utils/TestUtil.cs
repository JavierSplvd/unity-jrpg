using System.Runtime.Serialization;
using UnityEngine;

public class TestUtil
{
    private class BattleSystemProxy : BattleSystem
    {
        public override void ChangeState(State<BattleSystem> newState)
        {
            
        }
    }

    public static T Create<T>() 
    {
        return (T) FormatterServices.GetUninitializedObject(typeof(T));
    }

    public static UnitSO CreateUnit()
    {
        UnitSO unit = ScriptableObject.CreateInstance<UnitSO>();
        unit.currentDebuffs = new Debuff[0] {};
        return unit;
    }

    public static BattleSystem CreateBattleSystem()
    {
        return new BattleSystemProxy();
    }

}