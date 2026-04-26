//****************************************************************************
// File Name :         QuestPoints.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     quest system for the player
//****************************************************************************
using UnityEngine;
using TMPro;

public class QuestPoints : MonoBehaviour
{
    public int questPoints;
    [SerializeField] private int questPointsRequired;
    [SerializeField] private GameObject questReward;
    [SerializeField] private Vector3 transformOffset;
    [SerializeField] private int gameObjectAmount;
    [SerializeField] private TMP_Text questText;
    [SerializeField] private string QT1;
    [SerializeField] private string QT2;
    private bool hasRewarded;

    void Start(){
        hasRewarded = false;
    }

//quest system
    void Update()
    {
        //if you have enough quest points, summon thing.
        if(questPoints >= questPointsRequired && hasRewarded == false)
        {
            hasRewarded = true;
            for(int i = 0; i < gameObjectAmount; i++){
            Instantiate(questReward, new Vector3(transform.position.x + transformOffset.x, transform.position.y + transformOffset.y,
                transform.position.z + transformOffset.z), Quaternion.identity);
            }
        }
        if(questPointsRequired > 1){
            questText.text = QT1 + " " + questPoints + "/" + questPointsRequired + " " + QT2;
        } else {
            questText.text = QT1 + " " + QT2;
        }
    }
}
