using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TimerButton : MonoBehaviour
{
    private Timer timer;
    
    public GameObject timerButton;
    public InputActionReference rightControllerTriggerPressed;
    public InputActionReference leftControllerTriggerPressed;
    public bool turnOn = false;


    private void Awake()
    {
        rightControllerTriggerPressed.action.Enable();
        leftControllerTriggerPressed.action.Enable();
        rightControllerTriggerPressed.action.performed += ToggleTimer;
        leftControllerTriggerPressed.action.performed += ToggleTimer;
        turnOn = !turnOn;
        
    }

    private void OnDisable()
    {
        rightControllerTriggerPressed.action.Disable();
        leftControllerTriggerPressed.action.Disable();
        rightControllerTriggerPressed.action.performed -= ToggleTimer;
        leftControllerTriggerPressed.action.performed -= ToggleTimer;
    }

    private void ToggleTimer(InputAction.CallbackContext context)
    {
        //timerButton.SetActive(!timerButton.activeSelf);
        if (turnOn)
        {
            timer = timerButton.GetComponent<Timer>();
            timer.TurnTimerOn();
        }
        else
        {
            timer.TurnTimerOff();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
