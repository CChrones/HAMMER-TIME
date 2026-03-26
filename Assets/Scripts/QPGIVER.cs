//****************************************************************************
// File Name :         QPGIVER.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     integer for the quest objectives
//****************************************************************************
using UnityEngine;

public class QPGIVER : MonoBehaviour
{
    [SerializeField] private QuestPoints QP;
    private void OnDestroy()
    {
        Debug.Log("Destroyed");
        QP.questPoints++;
    }
}
