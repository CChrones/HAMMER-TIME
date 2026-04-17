//****************************************************************************
// File Name :         RockAI.cs
// Author :            Cameron Chrones
// Creation Date :     April 16th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     primary method of attack against the final boss
//****************************************************************************
using UnityEngine;
using System.Threading.Tasks;
public class RockAI : MonoBehaviour
{
    private bool canDoIt;
    private int currentIndex;
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private Transform bossTransform;
    [SerializeField] private EnemyHealth EH;
    private bool isTouchingMovePoint;
    private bool isMoving;
    private bool isBeingLaunched;
    [SerializeField] private float speed = 100f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isTouchingMovePoint = false;
        isMoving = false;
        isBeingLaunched = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void OnEnable()
    {
        //fixes issue of moving prematurely
        if(canDoIt){
        MoveRock(); 
        }
        canDoIt = true;
    }
    void FixedUpdate(){
        //controls rock movement
        if(isMoving == true && isTouchingMovePoint == false){
        Vector3 newPos = Vector3.MoveTowards(rb.position, movePoints[currentIndex].position, speed);
        rb.MovePosition(newPos);
        }
        if(isBeingLaunched == true){
        Vector3 newPos = Vector3.MoveTowards(rb.position, bossTransform.position, speed);
        rb.MovePosition(newPos);
        }
        if(EH == null)
        {
            Destroy(gameObject);
        }
    }
    //moves rock to one of the spawn points
    private void MoveRock()
    {
        currentIndex = UnityEngine.Random.Range(0, movePoints.Length - 1);
        isMoving = true;
    }
    //launches rock at boss
    private void LaunchRock()
    {
        isMoving = false;
        isBeingLaunched = true;
    }
    //chooses when moverock and launchrock are triggered
    private async Task OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("RockMovePoint")){
            isTouchingMovePoint = true;
            isMoving = false;
        }
        if (triggerObject.gameObject.CompareTag("HammerHitbox")){
            LaunchRock(); 
        }
        if(triggerObject.gameObject.CompareTag("BossFace")){
            isBeingLaunched = false;
            rb.position = new Vector3(0, 50, 0);
            EH.health -= 10;
            EH.IFrameActive();
            await Task.Delay(2000);
            MoveRock();
        }
    }
    private void OnTriggerExit(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("RockMovePoint")){
            isTouchingMovePoint = false;
        }
    }
}
