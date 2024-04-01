using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{

    public Rigidbody rb;
    // Method to 
    private Boolean isFloating;
    // Amount of upward force, to be changed as needed for the right effect. 
    public float upwardForce;

    // Grabbable stuff
    OVRGrabbable grabbable;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isFloating = false;
        grabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFloating)
        {
            // If it is floating, then we can start to add an upward force https://docs.unity3d.com/2020.3/Documentation/ScriptReference/Rigidbody.html
            rb.AddForce(Vector3.up * upwardForce, ForceMode.Acceleration);
        }

        // Now we can just check if it is grabbed and the trigger is pressed, using the script from the github https://github.com/AlexWills37/UnityQuest2020Template
        if (grabbable.isGrabbed && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            // Stop the object from using gravity, and update is floating to true; 
            rb.useGravity = false;
            isFloating = true; 
        }
    }

}
