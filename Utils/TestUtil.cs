using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization;

public class TestUtil
{
    private class BattleSystemProxy : BattleSystem
    {
        public override void ChangeState(State<BattleSystem> newState)
        {
            
        }
    }

    public static T CreateUnity<T>() 
    {
        GameObject go = new GameObject();
        if(typeof(T) == typeof(Animator))
        {
            go.AddComponent<Animator>();
        }
        else if(typeof(T) == typeof(Image))
        {
            go.AddComponent<Image>();
        }
        return go.GetComponent<T>();
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