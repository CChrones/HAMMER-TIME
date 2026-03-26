//****************************************************************************
// File Name :         BigCoinBehavior.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     movement of the Big Coin
//****************************************************************************
using UnityEngine;
using System.Threading.Tasks;

public class BigCoinBehavior : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float hoverSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async Task Start()
    {
        
        rb = GetComponent<Rigidbody>();
        //launches big coin up into the air with slightly random horizontal velocity
        rb.AddForce(UnityEngine.Random.Range(-1.0f, 1.0f), hoverSpeed, UnityEngine.Random.Range(-1.0f, 1.0f), ForceMode.Impulse); 
        await Dissipate();
    }

    //disappears after 3 seconds
    private async Task Dissipate()
    {
        await Task.Delay(3000);
        Destroy(gameObject);
    }
}
