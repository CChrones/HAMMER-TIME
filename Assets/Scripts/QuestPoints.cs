//****************************************************************************
// File Name :         QuestPoints.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     quest system for the player
//****************************************************************************
using UnityEngine;

public class QuestPoints : MonoBehaviour
{
    public int questPoints;
    [SerializeField] private int questPointsRequired;
    [SerializeField] private GameObject questReward;
    [SerializeField] private Vector3 transformOffset;
    [SerializeField] private int gameObjectAmount;

//quest system
    void Update()
    {
        if(questPoints >= questPointsRequired)
        {
            questPoints = 0;
            for(int i = 0; i < gameObjectAmount; i++){
            Instantiate(questReward, new Vector3(transform.position.x + transformOffset.x, transform.position.y + transformOffset.y,
                transform.position.z + transformOffset.z), Quaternion.identity);
            }
        }
    }
}
