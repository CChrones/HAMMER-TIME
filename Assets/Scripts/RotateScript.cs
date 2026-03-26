//****************************************************************************
// File Name :         RotateScript.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Automatic rotation of specific items (key, coins)
//****************************************************************************
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
    }
}
