using UnityEngine;
using System.Threading.Tasks;

public class BigCoinBehavior : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float hoverSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async Task Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.AddForce(UnityEngine.Random.Range(-1.0f, 1.0f), hoverSpeed, UnityEngine.Random.Range(-1.0f, 1.0f), ForceMode.Impulse); 
        await Dissipate();
    }

    // Update is called once per frame
    private async Task Dissipate()
    {
        await Task.Delay(3000);
        Destroy(gameObject);
    }
}
