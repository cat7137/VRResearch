using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateOnGrab : MonoBehaviour
{
    public bool isGrabbed = false;
    private Vector3 lastControllerPosition;
    private Quaternion originalRotation;
    private Rigidbody rb;
    //private XRController controller;

    public GameObject controllerObject;
    // Start is called before the first frame update
    void Start()
    {
        //originalRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        //controller = GetComponent<XRController>();  
    }

    // Update is called once per frame
    void Update()
    {
        //if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool gripValue) && gripValue)
       
        if (isGrabbed)
        {
            Vector3 controllerPosition = controllerObject.transform.position;//get current controller position
            Vector3 rotationDelta = controllerPosition - lastControllerPosition;
            Quaternion rotationChange = Quaternion.FromToRotation(Vector3.forward, rotationDelta.normalized);
            transform.rotation *= rotationChange;
            lastControllerPosition = controllerPosition;
        }
        
        
    }

    public void GrabBegin(ActivateEventArgs arg)
    {
        isGrabbed=true;
        Debug.Log("Begin is used!");
        rb.isKinematic=true;
        lastControllerPosition = controllerObject.transform.position;// get initial position of controller
    }

    public void GrabEnd(DeactivateEventArgs arg)
    {
        isGrabbed = false;
        rb.isKinematic =false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
