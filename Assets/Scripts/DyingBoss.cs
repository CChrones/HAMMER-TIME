//****************************************************************************
// File Name :         DyingBoss.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     final boss death animation
//****************************************************************************
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
public class DyingBoss : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async Task Start()
    {
        rb = GetComponent<Rigidbody>();
        await DeleteProj();
    }

    void FixedUpdate() {
    rb.linearVelocity = transform.up * -speed;
    }
    private async Task DeleteProj()
    {
        //destroys self and makes you win the game
        await Task.Delay(12000);
        Destroy(gameObject);
        SceneManager.LoadScene(5); 
    }
}
