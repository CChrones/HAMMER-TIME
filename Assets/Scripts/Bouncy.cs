//****************************************************************************
// File Name :         Bouncy.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Bouncy Props in Level 2
//****************************************************************************
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    [SerializeField] private Rigidbody target; 
    [SerializeField] private float boostVelocity;

    private void OnCollisionEnter(Collision triggerObject)
    {
        //bounces target if player touches object
        if (triggerObject.gameObject.CompareTag("Player")){
            target.linearVelocity = new Vector3(target.linearVelocity.x, boostVelocity, target.linearVelocity.z);
        }
    }
    
}
