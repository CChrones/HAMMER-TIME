//****************************************************************************
// File Name :         ExitScript.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     ability to exit the game
//****************************************************************************
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Quit(){
        Application.Quit();
    }
}
