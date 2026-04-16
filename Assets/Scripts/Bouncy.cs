using UnityEngine;

public class Bouncy : MonoBehaviour
{
    [SerializeField] private Rigidbody target; 
    [SerializeField] private float boostVelocity;

    private void OnCollisionEnter(Collision triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Player")){
            target.linearVelocity = new Vector3(target.linearVelocity.x, boostVelocity, target.linearVelocity.z);
        }
    }
    
}
