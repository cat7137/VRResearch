using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Rotate : MonoBehaviour
{
    private XRController controller;
    private InputAction action;
    public float rotationSpeed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<XRController>();
        action = new InputAction(binding: "<XRController>/thumbstick");
        action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 thumbstickInput = action.ReadValue<Vector2>();
        transform.Rotate(0f, thumbstickInput.x * rotationSpeed * Time.deltaTime, 0f);
    }

}
