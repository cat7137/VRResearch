using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckGrab : MonoBehaviour
{
    private RotateOnGrab rotateOnGrab;
    public XRGrabInteractable grabbable;
    // Start is called before the first frame update
    void Start()
    {
        rotateOnGrab = GetComponent<RotateOnGrab>();
        grabbable = GetComponent<XRGrabInteractable>();
        if (grabbable != null)
        {
            
            grabbable.activated.AddListener(rotateOnGrab.GrabBegin);
            grabbable.deactivated.AddListener(rotateOnGrab.GrabEnd);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
   
}
