using UnityEngine;
using System.Threading.Tasks;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int iFramesValue;
    private bool iFrames;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        iFrames = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider HammerHitbox)
    {
        if(iFrames == false)
        {
            health--;
            IFrameActive();
        }
    }
    private async Task IFrameActive()
    {
        iFrames = true;
        await Task.Delay(iFramesValue);
        iFrames = false;
    }
}
