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
    private InputAction smashHammer;
    private Vector3 playerMovement;
    private Rigidbody rb;
    [SerializeField] public float playerSpeed;
    [SerializeField] private Transform cameraTransform; 
    public bool canMove;
    [SerializeField] private GameObject hammerHitbox;
    private int movingWayCamera;
    [SerializeField] private float cameraSpeed;
    private bool canHammer;
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

        smashHammer.performed += SmashHammer;
        canMove = true;
        canHammer = true;
        hammerHitbox.SetActive(false);
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
    
    private void SmashHammer(InputAction.CallbackContext obj)
    {
        if(canHammer){
        hammerHitbox.SetActive(true);
        canHammer = false;
        RestHammerHitbox();
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

        moveL.performed -= MoveLPerformed;
        moveL.canceled -= MoveLCanceled;

        moveR.performed -= MoveRPerformed;
        moveR.canceled -= MoveRCanceled;
    }
    private async Task RestHammerHitbox()
    {
        await Task.Delay(100);
        hammerHitbox.SetActive(false);
        await Task.Delay(1000);
        canHammer = true;
    }
}
