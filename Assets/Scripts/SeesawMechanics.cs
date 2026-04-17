//****************************************************************************
// File Name :         SeesawMechanics.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Seesaws found in lvls 1 and 2
//****************************************************************************
using UnityEngine;
using System.Threading.Tasks;
public class SeesawMechanics : MonoBehaviour
{
    private bool isTouchingPlayer;
    [SerializeField] private Rigidbody target; 
    [SerializeField] private float boostVelocity;
    public bool isLeftDown;
    private bool seesawCooldown;
    void Start()
    {
        //target = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        seesawCooldown = false;
        isLeftDown = true;
    }
    void Update()
    {
        if(seesawCooldown == true)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        } else
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
    private async Task OnTriggerEnter(Collider HammerHitbox)
    {
        //switches state of seesaw if hit by hammer, launches you if you're in contact with it.
        if (HammerHitbox.gameObject.CompareTag("HammerHitbox") && seesawCooldown == false)
        {
            if(isTouchingPlayer == true){
            target.linearVelocity = new Vector3(target.linearVelocity.x, boostVelocity, target.linearVelocity.z);
            }
            if (isLeftDown)
            {
                transform.eulerAngles = new Vector3(-10, transform.eulerAngles.y, transform.eulerAngles.z);
                isLeftDown = false;
                seesawCooldown = true;
                await SeesawOnCooldown();
            } else
            {
                transform.eulerAngles = new Vector3(10, transform.eulerAngles.y, transform.eulerAngles.z);
                isLeftDown = true;
                seesawCooldown = true;
                await SeesawOnCooldown();
            }

        }
    }
    private void OnCollisionEnter(Collision triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Player")){
            isTouchingPlayer = true;
        }
    }
    private void OnCollisionExit(Collision triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Player")){
            isTouchingPlayer = false;
        }
    }
    //seesaw cooldown
    private async Task SeesawOnCooldown()
    {
        await Task.Delay(100);
        seesawCooldown = false;
    }
}
