//****************************************************************************
// File Name :         EndDoor.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     door that serves as the end goal for the level
//****************************************************************************
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndDoor : MonoBehaviour
{
    [SerializeField] private FinalStrike FS;
    [SerializeField] private int sceneNumber;
    
    private void OnCollisionEnter(Collision triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Player") && FS.finalStrikeWon == true)
        {
            SceneManager.LoadScene(sceneNumber); 
        }
    }
}
