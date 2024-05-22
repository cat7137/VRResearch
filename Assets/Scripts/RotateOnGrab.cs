using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.InputSystem;

public class RotateOnGrab : MonoBehaviour
{

    [Header("Controller")]
    public XRController xrController;
    

    [Header("Object")]
    public GameObject rotatedObject;

    [Header("Activation Settings")]
    public float activationDistance;

    private Quaternion currentRot;
    private Vector3 startPos;
    private bool offsetSet;

    private void Start()
    {
        offsetSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (xrController.inputDevice. && triggerValue > 0 && IsCloseEnough())
            Rotate();
        else
            offsetSet = false;

        if (OVRInput.GetDown(resetRotationButton))
            robot.transform.eulerAngles = Vector3.zero;
    }

    void SetOffsets()
    {
        if (offsetSet)
            return;

        startPos = Vector3.Normalize(transform.position - robot.transform.position);
        currentRot = robot.transform.rotation;

        offsetSet = true;
    }

    void Rotate()
    {
        SetOffsets();

        Vector3 closestPoint = Vector3.Normalize(transform.position - robot.transform.position);
        robot.transform.rotation = Quaternion.FromToRotation(startPos, closestPoint) * currentRot;
    }

    bool IsCloseEnough()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, robot.transform.position)) < activationDistance)
            return true;

        return false;
    }
}
