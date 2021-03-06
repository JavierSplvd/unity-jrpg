using UnityEngine;

public class RandomWrapper {
    public static bool test = false;

    public static float Range(float amplitude)
    {
        if(test)
        {
            return 1;
        }
        return Random.Range(1 - amplitude / 2, 1 + amplitude / 2);
    }
}