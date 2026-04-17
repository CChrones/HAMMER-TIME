//****************************************************************************
// File Name :         HammerProjController.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     behavior of the Hammer Projectile
//****************************************************************************
using UnityEngine;
using System.Threading.Tasks;
public class HammerProjController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async Task Start()
    {
        rb = GetComponent<Rigidbody>();
        await DeleteProj();
    }

    void FixedUpdate() {
        //moves forward until death
    rb.linearVelocity = transform.forward * speed;
    }
    private async Task DeleteProj()
    {
        //death
        await Task.Delay(1000);
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
