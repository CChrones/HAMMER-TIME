//****************************************************************************
// File Name :         BuyHammerProjectile.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Buy Hammer Projectile button
//****************************************************************************
using UnityEngine;

public class BuyHammerProjectile : MonoBehaviour
{
void Start()
    {
        if(AbilitiesUnlocked.hasHammerProjectile == true)
        {
            Destroy(gameObject);
        }
    }
    public void DoBuyHammerProjectile()
    {
        if(BitsCurrencyStorer.coinCount >= 200)
        {
            BitsCurrencyStorer.coinCount -= 200;
            AbilitiesUnlocked.hasHammerProjectile = true;
            Destroy(gameObject);
        }
        
    }
}
