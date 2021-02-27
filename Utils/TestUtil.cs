using System.Runtime.Serialization;
using UnityEngine;

public class TestUtil
{
    public static T Create<T>() 
    {
        return (T) FormatterServices.GetUninitializedObject(typeof(T));
    }

    public static UnitSO CreateUnit()
    {
        return ScriptableObject.CreateInstance<UnitSO>();
    }

}