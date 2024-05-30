using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchObject : MonoBehaviour
{

    public List<GameObject> objects;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public InputActionReference switchButton;
    public bool buttonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        object1.SetActive(true);
        object2.SetActive(false); 
        object3.SetActive(false);
        objects = new List<GameObject>();
        objects.Add(object1);
        objects.Add(object2);
        objects.Add(object3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        switchButton.action.Enable();
        switchButton.action.performed += ButtonPushed;
    }


    private void ButtonPushed(InputAction.CallbackContext context)
    {
        buttonPressed = true;
        if (buttonPressed)
        {
            objects[0].SetActive(false);
            objects.RemoveAt(0);
            objects[0].SetActive(true);
            buttonPressed = false;



        }
    }

    private void OnDisable()
    {
        switchButton.action.Disable(); 
        switchButton.action.performed -= ButtonPushed;
    }
}
