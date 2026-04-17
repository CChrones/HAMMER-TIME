//****************************************************************************
// File Name :         ElevatorControl.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Elevator system
//****************************************************************************
using UnityEngine;
using System;
public class ElevatorControl : MonoBehaviour
{
    [SerializeField] private ElevatorButtons EB;
    [SerializeField] private Vector3 offLocation;
    [SerializeField] private Vector3 onLocation;
    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        //moves depending on if elevator button is off or on
        if(EB.buttonState == false){
            transform.position = Vector3.MoveTowards(transform.position, offLocation, step);
        } else if(EB.buttonState == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, onLocation, step);
        }
    }
}
