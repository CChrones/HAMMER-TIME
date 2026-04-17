//****************************************************************************
// File Name :         BuyHammerProjectile.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Buy Hammer Hover button
//****************************************************************************
using UnityEngine;

public class BuyHammerSpin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(AbilitiesUnlocked.hasHammerSpin == true)
        {
            Destroy(gameObject);
        }
    }
    public void DoBuyHammerSpin()
    {
        if(BitsCurrencyStorer.coinCount >= 100)
        {
            BitsCurrencyStorer.coinCount -= 100;
            AbilitiesUnlocked.hasHammerSpin = true;
            Destroy(gameObject);
        }
        
    }
}
