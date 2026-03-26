//****************************************************************************
// File Name :         PortalSummonScript.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     abilities of the Portal enemy
//****************************************************************************
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
public class PortalSummonScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesToSummon = new List<GameObject>();
    [SerializeField] private List<GameObject> enemiesSummoned = new List<GameObject>();
    private bool canDoIt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    async Task OnEnable()
    {
        //fixes issue of summoning before portals are spawned
        if(canDoIt){
        await SummonFromPortal(); 
        }
        canDoIt = true;
    }
    private async Task SummonFromPortal()
    {
        for(int i = 0; i < enemiesToSummon.Count;)
        {
            CleanESList();
            if(enemiesSummoned.Count < 2)
            {
                enemiesSummoned.Add(Instantiate(enemiesToSummon[i], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity));
                enemiesToSummon.Remove(enemiesToSummon[i]);
                await Task.Delay(5000);
            }
            else
            {
                await Task.Delay(5000);
            }
        }
    }
    void CleanESList()
    {
        // Remove all entries where the item is null
        enemiesSummoned.RemoveAll(gameObject => gameObject == null);
        Debug.Log("List cleaned. New count: " + enemiesSummoned.Count);
    }
}
