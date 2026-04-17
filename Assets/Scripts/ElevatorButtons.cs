//****************************************************************************
// File Name :         ElevatorButtons.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Buttons found in Level 1
//****************************************************************************
using UnityEngine;
using System.Threading.Tasks;
public class ElevatorButtons : MonoBehaviour
{
    private bool buttonCooldown;
    public bool buttonState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private async Task OnTriggerEnter(Collider HammerHitbox)
    {
        //Changes button state and puts button on cooldown if hit with hammer or hammer projectile
        if ((HammerHitbox.gameObject.CompareTag("HammerHitbox") || HammerHitbox.gameObject.CompareTag("HammerProjHitbox")) && buttonCooldown == false)
        {
            buttonState = !buttonState;
            buttonCooldown = true;
            await ButtonOnCooldown();
        }
    }
    private async Task ButtonOnCooldown()
    {
        await Task.Delay(1000);
        buttonCooldown = false;
    }
}
