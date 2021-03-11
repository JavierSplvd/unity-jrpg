using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileConfig : MonoBehaviour
{
    float ratio = 640 / 320;
    float currentWidth, currentHeight;
    // Start is called before the first frame update
    void Start()
    {
        currentHeight = Screen.height;
        currentWidth = Screen.width;

        int targetWidth = (int) (currentHeight * ratio);

        Screen.SetResolution(targetWidth, (int) currentHeight, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
