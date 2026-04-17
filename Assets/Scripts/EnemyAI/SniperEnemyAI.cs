//****************************************************************************
// File Name :         SniperEnemyAI.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Sniper enemy type (that currently goes unused)
//****************************************************************************
using UnityEngine;

public class SniperEnemyAI : MonoBehaviour
{
[SerializeField] private GameObject[] movePoints;
    [SerializeField] private float speed;
    private int currentIndex;
    private bool watching;
    [SerializeField] private GameObject target; 
    [SerializeField] private int viewRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
        watching = false;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //tracks if player is within viewRange units of the enemy
        if(target.transform.position.x < transform.position.x + viewRange && target.transform.position.x > transform.position.x - viewRange 
            && target.transform.position.y < transform.position.y + viewRange && target.transform.position.y > transform.position.y - viewRange
                && target.transform.position.z < transform.position.z + viewRange && target.transform.position.z > transform.position.z - viewRange)
        {
            watching = true;
        } else
        {
            watching = false;
        }
//if not watching, follows path. if watching, stands still.
        if (watching == false)
        {
            if(Vector3.Distance(transform.position, movePoints[currentIndex].transform.position) < 0.1f)
            {
            currentIndex++;

                if(currentIndex >= movePoints.Length)
                {
                currentIndex = 0;
                }
            }
        
            transform.position = Vector3.MoveTowards(transform.position, movePoints[currentIndex].transform.position,
            speed * Time.deltaTime);
        }  
        else
        {
            
        }
    }
}
