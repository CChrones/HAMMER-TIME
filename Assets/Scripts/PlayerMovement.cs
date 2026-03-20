using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private InputAction moveF;
    private InputAction moveB;
    private Vector3 playerMovement;
    private Rigidbody rb;
    [SerializeField] public float playerSpeed;
    [SerializeField] private Transform cameraTransform; 

    public bool canMove;

    public int movingWay;
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

        moveF.performed += MoveFPerformed;
        moveF.canceled += MoveFCanceled;

        moveB.performed += MoveBPerformed;
        moveB.canceled += MoveBCanceled;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            if(movingWay == 1){
                transform.Translate(cameraTransform.forward * Time.deltaTime * playerSpeed);
            }
            if(movingWay == 2){
                transform.Translate(-cameraTransform.forward * Time.deltaTime * playerSpeed);
            }
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
    private void OnDestroy()
    {
        moveF.performed -= MoveFPerformed;
        moveF.canceled -= MoveFCanceled;

        moveB.performed -= MoveBPerformed;
        moveB.canceled -= MoveBCanceled;
    }
}
