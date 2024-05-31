using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchObject : MonoBehaviour
{
    public GameObject controller;
    public List<GameObject> objects;
    public InputActionReference switchButton;
    public bool buttonPressed = false;

    private void Awake()
    {

        switchButton.action.Enable();
        switchButton.action.performed += ButtonPushed;
       
    }

    private void OnDisable()
    {
        switchButton.action.Disable();
        switchButton.action.performed -= ButtonPushed;
    }

// Start is called before the first frame update
void Start()
    {
       
        //objects = new List<GameObject>(3);
        objects[0].SetActive(true);
        objects[1].SetActive(false);
        objects[2].SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            
                objects[0].SetActive(false);
            if (objects.Count > 1)
            {
                objects.RemoveAt(0);
                objects[0].SetActive(true);
                buttonPressed = false;
            }
            



        }
    }

   


    private void ButtonPushed(InputAction.CallbackContext context)
    {
        buttonPressed = true;
       // if (buttonPressed)
       // {
           // objects[0].SetActive(false);
           // objects.RemoveAt(0);
           // objects[0].SetActive(true);
           // buttonPressed = false;



       // }
    }

    
}
