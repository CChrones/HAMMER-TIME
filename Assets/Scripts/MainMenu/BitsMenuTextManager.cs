//****************************************************************************
// File Name :         BitsMenuTextManager.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Bits text in the menu
//****************************************************************************
using UnityEngine;
using TMPro;
public class BitsMenuTextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text bitsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bitsText.text = "Bits: " + BitsCurrencyStorer.coinCount.ToString();
    }
}
