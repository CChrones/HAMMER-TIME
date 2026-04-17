//****************************************************************************
// File Name :         Billboarding.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Billboarding of 2d sprites (only used for level 2's cats)
//****************************************************************************
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        // Cache the main camera's transform for performance
        cameraTransform = Camera.main.transform;
    }

    // Use LateUpdate to ensure the camera has finished moving for the frame
    void LateUpdate()
    {
        // Makes the object's rotation match the camera's rotation exactly
        transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward,
                         cameraTransform.rotation * Vector3.up);
    }
}
