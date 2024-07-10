using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TimerButton : MonoBehaviour
{
    public Timer timer;
    public GameObject stop;
    public Button startButton;

    private void Awake()
    { 
        startButton.onClick.AddListener(ToggleTimer);
    }


    private void ToggleTimer()
    {
           timer.TurnTimerOn();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stop.activeSelf)
        {
            timer.TurnTimerOff();
        }
    }
}
