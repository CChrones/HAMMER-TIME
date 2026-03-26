//****************************************************************************
// File Name :         BaseEnemyAI.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     movement for the basic enemy
//****************************************************************************
using UnityEngine;

public class BaseEnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float speed;
    private int currentIndex;
    private bool chasing;
    [SerializeField] private GameObject target; 
    [SerializeField] private int viewRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
        chasing = false;
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
            chasing = true;
        } else
        {
            chasing = false;
        }
//if not chasing, follows path. if chasing, doesnt follow path.
        if (chasing == false)
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
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position,
            speed * Time.deltaTime);
        }
        //Check distance between object and movepoint
        
    }
}
