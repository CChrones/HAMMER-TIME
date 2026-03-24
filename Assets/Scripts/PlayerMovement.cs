using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private InputAction moveR;
    private InputAction moveL;
    private InputAction moveF;
    private InputAction moveB;
    private InputAction moveValue;
    private InputAction smashHammer;
    private Vector3 playerMovement;
    private Rigidbody rb;
    [SerializeField] public float playerSpeed;
    [SerializeField] private Transform cameraTransform; 
    public bool canMove;
    public int movingWay;
    [SerializeField] private GameObject hammerHitbox;
    private int movingWayCamera;
    [SerializeField] private float cameraSpeed;
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
        moveR = InputSystem.actions.FindAction("MoveR");
        moveL = InputSystem.actions.FindAction("MoveL");
        moveValue = InputSystem.actions.FindAction("Move");
        moveR.performed += MoveRPerformed;
        moveR.canceled += MoveRCanceled;

        moveL.performed += MoveLPerformed;
        moveL.canceled += MoveLCanceled;

        moveF.performed += MoveFPerformed;
        moveF.canceled += MoveFCanceled;

        moveB.performed += MoveBPerformed;
        smashHammer.performed += SmashHammer;
        moveB.canceled += MoveBCanceled;
        canMove = true;
    }

    // Update is called once per frame
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
    }
    private void MoveFPerformed(InputAction.CallbackContext obj)
    {
        movingWay = 1;
    }

    private void MoveFCanceled(InputAction.CallbackContext obj)
    {
        if(movingWay == 1){
        movingWay = 0;
        }
    }
    private void SmashHammer(InputAction.CallbackContext obj)
    {
        
    }

    private void MoveBPerformed(InputAction.CallbackContext obj)
    {
        movingWay = 2;
    }

    private void MoveBCanceled(InputAction.CallbackContext obj)
    {
        if(movingWay == 2){
        movingWay = 0;
        }
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
        moveF.performed -= MoveFPerformed;
        moveF.canceled -= MoveFCanceled;

        moveB.performed -= MoveBPerformed;
        moveB.canceled -= MoveBCanceled;

        moveL.performed -= MoveLPerformed;
        moveL.canceled -= MoveLCanceled;

        moveR.performed -= MoveRPerformed;
        moveR.canceled -= MoveRCanceled;
    }
}
