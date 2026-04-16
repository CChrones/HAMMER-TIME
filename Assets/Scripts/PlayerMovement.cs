//****************************************************************************
// File Name :         PlayerMovement.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     movement for the player
//****************************************************************************
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
public class PlayerMovement : MonoBehaviour
{
    private InputAction moveR;
    private InputAction moveL;
    private InputAction moveF;
    private InputAction moveB;
    private InputAction moveValue;
//Combat Actions
    private InputAction smashHammer;
    private InputAction spinHammer;
//end of combat actions
    private Vector3 playerMovement;
    private Rigidbody rb;
    [SerializeField] public float playerSpeed;
    [SerializeField] private Transform cameraTransform; 
    public bool canMove;
    [SerializeField] private GameObject hammerHitbox;
    [SerializeField] private GameObject spinHammerHitbox;
    private int movingWayCamera;
    [SerializeField] private float cameraSpeed;
    private bool canHammer;
    [SerializeField] private PlayerHealth PH;
    private bool isGliding;
    [SerializeField] private float glideValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (cameraTransform == null)
        {
            //Finds the main camera if not assigned in the Inspector
            cameraTransform = Camera.main.transform; 
        }
        rb = GetComponent<Rigidbody>();

        moveF = InputSystem.actions.FindAction("MoveF");
        moveB = InputSystem.actions.FindAction("MoveB");

        smashHammer = InputSystem.actions.FindAction("SmashHammer");

        spinHammer = InputSystem.actions.FindAction("SpinHammer");

        moveR = InputSystem.actions.FindAction("MoveR");
        moveL = InputSystem.actions.FindAction("MoveL");

        moveValue = InputSystem.actions.FindAction("Move");

        moveR.performed += MoveRPerformed;
        moveR.canceled += MoveRCanceled;

        moveL.performed += MoveLPerformed;
        moveL.canceled += MoveLCanceled;

        spinHammer.performed += SpinHammerPerformed;
        spinHammer.canceled += SpinHammerCanceled;

        smashHammer.performed += SmashHammer;
        canMove = true;
        canHammer = true;
        hammerHitbox.SetActive(false);
        spinHammerHitbox.SetActive(false);

        isGliding = false;
    }

    // moving forward and backwards, rotating left and right (camera follows)
    void FixedUpdate()
    {
        if(canMove){
            
            rb.linearVelocity = new Vector3(transform.forward.x * playerSpeed * moveValue.ReadValue<float>(), rb.linearVelocity.y, transform.forward.z * playerSpeed * moveValue.ReadValue<float>());
            if(movingWayCamera == 1){
                transform.RotateAround(transform.position, Vector3.up, cameraSpeed);
            }
            if(movingWayCamera == 2){
                transform.RotateAround(transform.position, -Vector3.up, cameraSpeed);
            }
            cameraTransform.rotation = transform.rotation;
        }
        if (isGliding)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y + glideValue, rb.linearVelocity.z);
        }
    }
    
    //basic hammer attack
    private void SmashHammer(InputAction.CallbackContext obj)
    {
        if(canHammer){
        hammerHitbox.SetActive(true);
        PH.iFrames = true;
        canHammer = false;
        RestHammerHitbox();
        }
    }
    private void SpinHammerPerformed(InputAction.CallbackContext obj)
    {
        if(canHammer && AbilitiesUnlocked.hasHammerSpin){
        spinHammerHitbox.SetActive(true);
        canHammer = false;
        isGliding = true;
        }
    }
    private void SpinHammerCanceled(InputAction.CallbackContext obj)
    {
        isGliding = false;
        RestHammerHitbox();
    }
    private void MoveRPerformed(InputAction.CallbackContext obj)
    {
        movingWayCamera = 1;
    }

    private void MoveRCanceled(InputAction.CallbackContext obj)
    {
        if(movingWayCamera == 1){
        movingWayCamera = 0;
        }
    }

    private void MoveLPerformed(InputAction.CallbackContext obj)
    {
        movingWayCamera = 2;
    }

    private void MoveLCanceled(InputAction.CallbackContext obj)
    {
        if(movingWayCamera == 2){
        movingWayCamera = 0;
        }
    }
    private void OnDestroy()
    {

        moveL.performed -= MoveLPerformed;
        moveL.canceled -= MoveLCanceled;

        moveR.performed -= MoveRPerformed;
        moveR.canceled -= MoveRCanceled;

        spinHammer.performed -= SpinHammerPerformed;
        spinHammer.canceled -= SpinHammerCanceled;

        smashHammer.performed -= SmashHammer;
    }
    //hammer cooldown and iframes on hammer
    private async Task RestHammerHitbox()
    {
        await Task.Delay(100);
        hammerHitbox.SetActive(false);
        spinHammerHitbox.SetActive(false);
        PH.iFrames = false;
        await Task.Delay(1000);
        canHammer = true;
    }
    
}
