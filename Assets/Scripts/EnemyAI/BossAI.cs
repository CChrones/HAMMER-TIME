//****************************************************************************
// File Name :         BossAI.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Boss Timer
//****************************************************************************
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using TMPro;
public class BossAI : MonoBehaviour
{
    public int timer;
    private bool canDoIt;
    [SerializeField] private TMP_Text timeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    async Task OnEnable()
    {
        //fixes issue of starting timer early
        if(canDoIt){
        await StartTimer(); 
        }
        canDoIt = true;
    }

    private async Task StartTimer()
    {
        await Task.Delay(1000);
        //stops ticking if boss dies or if time is 0
        if(timer > 0 && gameObject != null){
        timer--;
        timeText.text = timer.ToString();
        await StartTimer();
        } else {
            if(timer <= 0){
            SceneManager.LoadScene(6); 
            }
        }
    }
}
