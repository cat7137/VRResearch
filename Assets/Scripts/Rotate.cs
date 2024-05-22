using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Rotate : MonoBehaviour
{
    
    [SerializeField]private InputAction action;
    [SerializeField]private InputAction axis;
    public float rotationSpeed = 10;
    private bool rotateAllowed;
    private Vector2 rotation;
    
    // Start is called before the first frame update
    void Awake()
    {

        action.Enable();
        axis.Enable();
        action.performed += _ => { StartCoroutine(Rotates()); };
        action.canceled += _ => { rotateAllowed = false; };
        axis.performed += context => { rotation = context.ReadValue<Vector2>(); };
    }

    private IEnumerator Rotates()
    {
        rotateAllowed = true;
        while (rotateAllowed)
        {
            rotation *= rotationSpeed;
            transform.Rotate(Vector3.up, rotation.x, Space.World);
            transform.Rotate(Vector3.right, rotation.y, Space.World);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
