using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumiInput : MonoBehaviour
{
    public static NumiInput instance;

    public float forward;
    public float lateral;
    public bool stop;
    public bool fire;
    public float cameraVertical;
    public float cameraHorizontal;
    public bool cameraSwitch, dodge, jog, run, jump, interact, reload, menu, click;
    public bool keyboard = true;
    public Vector3 mousePosition;

    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keyboard)
        {
            KeyboardMouseControls();
        }
        else
        {
            GamepadControls();
        }

        foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            //if (UnityEngine.Input.GetKeyDown(kcode))
                //Debug.Log("KeyCode down: " + kcode);
        }
    }

    private void KeyboardMouseControls()
    {
        forward = UnityEngine.Input.GetAxis("Vertical");
        lateral = UnityEngine.Input.GetAxis("Horizontal");
        stop = UnityEngine.Input.GetKeyUp(KeyCode.LeftControl);
        cameraSwitch = UnityEngine.Input.GetKeyUp(KeyCode.Tab);
        fire = UnityEngine.Input.GetMouseButtonUp(0);
        // cameraVertical = UnityEngine.Input.GetKey(KeyCode.UpArrow)? 1 : UnityEngine.Input.GetKey(KeyCode.DownArrow)? -1 : 0;
        // cameraHorizontal = UnityEngine.Input.GetKey(KeyCode.RightArrow)? 1 : UnityEngine.Input.GetKey(KeyCode.LeftArrow)? -1 : 0;
        cameraVertical = UnityEngine.Input.GetAxis("Mouse Y");
        cameraHorizontal = UnityEngine.Input.GetAxis("Mouse X");
        
        reload = UnityEngine.Input.GetKeyUp(KeyCode.R);
        jump = UnityEngine.Input.GetKeyUp(KeyCode.Space);
        
        run =  UnityEngine.Input.GetKey(KeyCode.LeftShift);
        interact =  UnityEngine.Input.GetKeyUp(KeyCode.F);
        menu =  UnityEngine.Input.GetKeyUp(KeyCode.F1);

        click = UnityEngine.Input.GetMouseButtonUp(0);
        mousePosition = UnityEngine.Input.mousePosition;
    }

    private void GamepadControls()
    {
        forward = UnityEngine.Input.GetAxis("Vertical");
        lateral = UnityEngine.Input.GetAxis("Horizontal");
        // stop = UnityEngine.Input.GetButtonUp("");
        // cameraSwitch = UnityEngine.Input.GetButtonUp();
        // fire = UnityEngine.Input.GetButtonUp(KeyCode.Space);
        cameraVertical = UnityEngine.Input.GetAxis("Debug Vertical");
        cameraHorizontal = UnityEngine.Input.GetAxis("Debug Horizontal");
        
        dodge = UnityEngine.Input.GetKeyUp(KeyCode.Joystick1Button2);
        jump = UnityEngine.Input.GetKeyUp(KeyCode.Joystick1Button0);

        jog =  UnityEngine.Input.GetKey(KeyCode.Joystick1Button4);
        run =  UnityEngine.Input.GetKey(KeyCode.Joystick1Button5);
    }
}
