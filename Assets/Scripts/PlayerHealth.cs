//****************************************************************************
// File Name :         PlayerHealth.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Health system for the player
//****************************************************************************
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int playerHP;
    [SerializeField] private int iFramesValue;
    public bool iFrames;
    [SerializeField] private TMP_Text healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iFrames = false;
        healthText.text = "Health: " + playerHP.ToString();
    }
    //invincibility frames, sends you back on death.
    private async Task Hit()
    {
        iFrames = true;

        if(playerHP < 1)
        {
            SceneManager.LoadScene(0); 
        }
        await Task.Delay(iFramesValue);
        healthText.text = "Health: " + playerHP.ToString();
        iFrames = false;
    }
    private async Task OnCollisionEnter(Collision triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Enemy")){
        if(iFrames == false)
        {
            playerHP--;
            await Hit();
        }
        }
    }

}
