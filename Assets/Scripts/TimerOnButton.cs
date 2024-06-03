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
    //public GameObject timerOnButton;
    //public InputActionReference rightControllerTriggerPressed;
    public InputActionReference leftControllerButtonPressed;
    public bool turnOn = false;
    //private XRBaseInteractable interactable;


    private void Awake()
    {
        
        leftControllerButtonPressed.action.Enable();
        leftControllerButtonPressed.action.performed += ToggleTimer;
        
        //rightControllerTriggerPressed.action.performed += ToggleTimer;
        //leftControllerTriggerPressed.action.performed += ToggleTimer;
        

    }

    

    private void OnDisable()
    {
        
        leftControllerButtonPressed.action.Disable();
        leftControllerButtonPressed.action.performed -= ToggleTimer;
    }

    private void ToggleTimer(InputAction.CallbackContext context)
    {
        //timerOnButton.SetActive(!timerOnButton.activeSelf);
        //if (turnOn)
        //{
            
            //timer = timerOnButton.GetComponent<Timer>();
            timer.TurnTimerOn();
        //}
    }



    // Start is called before the first frame update
    void Start()
    {
        //interactable = GetComponent<XRBaseInteractable>();
        //interactable.hoverEntered.AddListener(TurnOn);
    }

    //private void TurnOn(HoverEnterEventArgs arg0)
    //{
       // turnOn = true;
        //leftControllerButtonPressed.action.performed += ToggleTimer;
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
