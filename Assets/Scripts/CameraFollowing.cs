using UnityEngine;
using UnityEngine.InputSystem;
public class CameraFollowing : MonoBehaviour
{
    private InputAction moveR;
    private InputAction moveL;
    private Rigidbody rb;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Transform playerObject; 
    [SerializeField] private PlayerMovement PM; 
    private bool canMoveCamera;

    private int movingWayCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveR = InputSystem.actions.FindAction("MoveR");
        moveL = InputSystem.actions.FindAction("MoveL");

        moveR.performed += MoveRPerformed;
        moveR.canceled += MoveRCanceled;

        moveL.performed += MoveLPerformed;
        moveL.canceled += MoveLCanceled;
        canMoveCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMoveCamera){
            if(movingWayCamera == 1){
                transform.RotateAround(playerObject.position, Vector3.up, cameraSpeed * Time.deltaTime);
            }
            if(movingWayCamera == 2){
                transform.RotateAround(playerObject.position, -Vector3.up, cameraSpeed * Time.deltaTime);
            }
        }
        /*if(PM.canMove){
            if(PM.movingWay == 1){
                transform.Translate(transform.forward * Time.deltaTime * PM.playerSpeed);
            }
            if(PM.movingWay == 2){
                transform.Translate(-transform.forward * Time.deltaTime * PM.playerSpeed);
            }
        }*/
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
    }
    
}
