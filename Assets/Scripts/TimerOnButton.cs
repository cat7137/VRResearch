using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TimerButton : MonoBehaviour
{
    public Timer timer;
    public GameObject timerOnButton;
    public InputActionReference rightControllerTriggerPressed;
    public InputActionReference leftControllerTriggerPressed;
    public bool turnOn = false;
    private XRBaseInteractable interactable;


    private void Awake()
    {
        rightControllerTriggerPressed.action.Enable();
        leftControllerTriggerPressed.action.Enable();
        
        //rightControllerTriggerPressed.action.performed += ToggleTimer;
        //leftControllerTriggerPressed.action.performed += ToggleTimer;
        

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
        //timerOnButton.SetActive(!timerOnButton.activeSelf);
        if (turnOn)
        {
            
            //timer = timerOnButton.GetComponent<Timer>();
            timer.TurnTimerOn();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(TurnOn);
    }

    private void TurnOn(HoverEnterEventArgs arg0)
    {
        turnOn = true;
        rightControllerTriggerPressed.action.performed += ToggleTimer;
        leftControllerTriggerPressed.action.performed += ToggleTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
