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
    private bool turnOn = false;


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
        if (timerButton.activeSelf)
        {
            timer = timerButton.GetComponent<Timer>();
            timer.TurnTimerOn();
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
