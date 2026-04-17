//****************************************************************************
// File Name :         GIVEMEMONEYDEBUG.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     giving money debug button
//****************************************************************************
using UnityEngine;

public class GIVEMEMONEYDEBUG : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GiveMeMoneyPleaseImBeggingYou()
    {
        BitsCurrencyStorer.coinCount += 100;
    }
}
