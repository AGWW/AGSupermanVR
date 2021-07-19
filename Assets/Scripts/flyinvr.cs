using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class flyinvr : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private float flyingSpeed = 0f;
    private bool isFlying = false;
    private Rigidbody myrigid;

    void Start()
    {
        myrigid = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        CheckIfFlying();
        FlyIfFlying();
    }

    private void CheckIfFlying()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            isFlying = true;
            myrigid.useGravity = false;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            isFlying = false;
            myrigid.useGravity = true;
        }
    }

    private void FlyIfFlying()
    {
        if (isFlying == true)
        {
            Vector3 flyDirection = leftHand.transform.position - head.transform.position;
            transform.position += flyDirection.normalized * flyingSpeed;
        }
    }
}
