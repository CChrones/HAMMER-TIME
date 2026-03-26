//****************************************************************************
// File Name :         FinalStrike.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     final battle at the end of each stage
//****************************************************************************
using UnityEngine;
using System.Collections.Generic;
public class FinalStrike : MonoBehaviour
{
    public bool finalStrikeWon;
    [SerializeField] private List<GameObject> enemiesToInitiate = new List<GameObject>();
    [SerializeField] private KeyController KC;
    // set enemies inactive at the start
    void Start()
    {
        for(int i = 0; i < enemiesToInitiate.Count; i++)
        {
            enemiesToInitiate[i].SetActive(false);
        }
        finalStrikeWon = false;
    }
    //automatically clean empty slots of list. when list is at 0, you've won the Final Strike.
    void Update()
    {
        enemiesToInitiate.RemoveAll(gameObject => gameObject == null);
        Debug.Log("List cleaned. New count: " + enemiesToInitiate.Count);
        if(enemiesToInitiate.Count == 0)
        {
            finalStrikeWon = true;
        }
    }
    //Initiates final strike when you have all keys and you enter the correct area 
    private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Player") && KC.keyCount >= KC.keyRequirement && finalStrikeWon == false)
        {
            for(int i = 0; i < enemiesToInitiate.Count; i++)
            {
                enemiesToInitiate[i].SetActive(true);
            }
        }
    }

}
