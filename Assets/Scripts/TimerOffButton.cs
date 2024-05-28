using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TimerOffButton : MonoBehaviour
{
    public Timer timer;
    public GameObject timerOffButton;
    public InputActionReference rightControllerTriggerPressed;
    public InputActionReference leftControllerTriggerPressed;
    public bool turnOff = false;
    private XRBaseInteractable interactable;


    private void Awake()
    {
        rightControllerTriggerPressed.action.Enable();
        leftControllerTriggerPressed.action.Enable();
    }

    private void OnDisable()
    {
        rightControllerTriggerPressed.action.Disable();
        leftControllerTriggerPressed.action.Disable();
    }

    private void ToggleTimer(InputAction.CallbackContext context)
    {
        //timerOnButton.SetActive(!timerOnButton.activeSelf);
        if (turnOff)
        {

            //timer = timerOffButton.GetComponent<Timer>();
            timer.TurnTimerOff();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(TurnOff);
    }

    private void TurnOff(HoverEnterEventArgs arg0)
    {
        turnOff = true;
        rightControllerTriggerPressed.action.performed += ToggleTimer;
        leftControllerTriggerPressed.action.performed += ToggleTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
