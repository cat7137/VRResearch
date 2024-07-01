using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchObject : MonoBehaviour
{
    [SerializeField]
    public GameObject UIButton;
    [SerializeField]
    public List<GameObject> objects;
    [SerializeField]
    //public InputActionReference switchButton;
    private Button btn = null;
    public bool buttonPressed = false;
    [SerializeField]
    public int buttonIndex = 0;

    private void Awake()
    {
        btn.onClick.AddListener(ButtonPushed);
        //switchButton.action.Enable();
       // switchButton.action.performed += ButtonPushed;
       
    }

   

    //private void OnDisable()
   // {
       // switchButton.action.Disable();
       // switchButton.action.performed -= ButtonPushed;
    //}

// Start is called before the first frame update
void Start()
    {
        
        //objects = new List<GameObject>(3);
        objects[0].SetActive(false);
        objects[1].SetActive(false);
        objects[2].SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            if (buttonIndex == 0)
            {
                objects[0].SetActive(true);
                buttonIndex = 1;
                buttonPressed = false;
            }
            else
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
    }

   


    private void ButtonPushed()
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
