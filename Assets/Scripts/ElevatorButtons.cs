using UnityEngine;
using System.Threading.Tasks;
public class ElevatorButtons : MonoBehaviour
{
    private bool buttonCooldown;
    public bool buttonState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider HammerHitbox)
    {
        
        if (HammerHitbox.gameObject.CompareTag("HammerHitbox") && buttonCooldown == false)
        {
            buttonState = !buttonState;
            buttonCooldown = true;
            ButtonOnCooldown();
        }
    }
    private async Task ButtonOnCooldown()
    {
        await Task.Delay(100);
        buttonCooldown = false;
    }
}
