using UnityEngine;
using System.Threading.Tasks;
public class SeesawMechanics : MonoBehaviour
{
    private bool isTouchingPlayer;
    [SerializeField] private Rigidbody target; 
    [SerializeField] private float boostVelocity;
    private bool isLeftDown;
    private bool seesawCooldown;
    void Start()
    {
        //target = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        seesawCooldown = false;
        isLeftDown = true;
    }
    private void OnTriggerEnter(Collider HammerHitbox)
    {
        if (HammerHitbox.gameObject.CompareTag("HammerHitbox") && seesawCooldown == false)
        {
            if(isTouchingPlayer == true){
            target.linearVelocity = new Vector3(target.linearVelocity.x, boostVelocity, target.linearVelocity.z);
            }
            if (isLeftDown)
            {
                transform.eulerAngles = new Vector3(-10, 0, 0);
                isLeftDown = false;
                seesawCooldown = true;
                SeesawOnCooldown();
            } else
            {
                transform.eulerAngles = new Vector3(10, 0, 0);
                isLeftDown = true;
                seesawCooldown = true;
                SeesawOnCooldown();
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
    private async Task SeesawOnCooldown()
    {
        await Task.Delay(100);
        seesawCooldown = false;
    }
}
