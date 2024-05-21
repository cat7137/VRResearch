using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Rotate : MonoBehaviour
{
    private InputAction rotateAction;
    public float rotationSpeed = 10;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        rotateAction = new InputAction(binding: "<Keyboard>/rightArrow"); //(binding: "<Gamepad>/rightStick/x")
        rotateAction.performed += ctx => RotateObject(ctx.ReadValue<float>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        rotateAction.Enable();
    }

    void OnDisable()
    {
        rotateAction.Disable();
    }

    void RotateObject(float rotateInput)
    {
        transform.Rotate(0f, rotateInput * rotationSpeed * Time.deltaTime, 0f);
    }
}
