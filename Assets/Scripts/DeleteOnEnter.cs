//****************************************************************************
// File Name :         DeleteOnEnter.cs
// Author :            Cameron Chrones
// Creation Date :     May 10th, 2026
// Brief Description : This file is 3D Platformer for IM 160, coding the
//                     Portal disappearing and UI appearing on the roof level
//****************************************************************************
using UnityEngine;

public class DeleteOnEnter : MonoBehaviour
{
    [SerializeField] private GameObject endPortal;
    [SerializeField] private GameObject doomUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Player"))
        {
            doomUI.SetActive(true);
            Destroy(endPortal);
            Destroy(gameObject);
        }
    }
}
