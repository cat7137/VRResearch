using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchObject : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public InputActionReference switchButton;
    public bool buttonPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects = new GameObject[3];
        gameObjects[0] = object1;
        gameObjects[1] = object2;
        gameObjects[2] = object3;
        gameObjects[0].SetActive(true);
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
        {
            GameObject temp = gameObjects[0];
            gameObjects[0] = gameObjects[1];
            gameObjects[0].SetActive(true);
            gameObjects[1] = gameObjects[2];
            gameObjects[2] = temp;
            gameObjects[2].SetActive(false);
            buttonPressed = false;
        }
    }

    private void Awake()
    {
        switchButton.action.Enable();
        switchButton.action.performed += ButtonPushed;
    }


    private void ButtonPushed(InputAction.CallbackContext context)
    {
        buttonPressed = true;
    }

    private void OnDisable()
    {
        switchButton.action.Disable(); 
        switchButton.action.performed -= ButtonPushed;
    }
}
