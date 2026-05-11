//****************************************************************************
// File Name :         MenuCameraMovement.cs
// Author :            Cameron Chrones
// Creation Date :     May 10th, 2026
// Brief Description : This file is 3D Platformer for IM 160, coding the
//                     movement of the camera in the main menu
//****************************************************************************
using UnityEngine;

public class MenuCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cameraTransform == null)
        {
            //Finds the main camera if not assigned in the Inspector
            cameraTransform = Camera.main.transform; 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraTransform.rotation = transform.rotation;
    }
}
