using System.Collections.Generic;
using System;

class DamageLogger
{
    private static Dictionary<string, float> damageList = new Dictionary<string, float>();

    public delegate void DamageDealt(string u, int i);
    public static event DamageDealt OnDamageDealt;

    public static void Add(string unitId, int value)
    {
        damageList.Add(unitId + "-" + damageList.Count, value);
        if(OnDamageDealt != null)
        {
            OnDamageDealt(unitId, value);
        }
        
    }
}