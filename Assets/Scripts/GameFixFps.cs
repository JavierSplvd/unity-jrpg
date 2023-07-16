using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFixFps : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 30;
    }
}
