//****************************************************************************
// File Name :         EnemyHealth.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     enemy health system
//****************************************************************************
using UnityEngine;
using System.Threading.Tasks;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int iFramesValue;
    private bool iFrames;
    [SerializeField] private GameObject coin;
    [SerializeField] private Vector3 transformOffset;
    [SerializeField] private int gameObjectAmount;
    [SerializeField] private bool killParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iFrames = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private async Task OnTriggerEnter(Collider HammerHitbox)
    {
        if(iFrames == false)
        {
            health--;
            await IFrameActive();
        }
    }
    private async Task IFrameActive()
    {
        iFrames = true;
        if(health < 1)
        {
            for(int i = 0; i < gameObjectAmount; i++){
            Instantiate(coin, new Vector3(transform.position.x + transformOffset.x, transform.position.y + transformOffset.y,
                transform.position.z + transformOffset.z), Quaternion.identity);
            }
            if (killParent)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
        await Task.Delay(iFramesValue);
        iFrames = false;
    }
}
