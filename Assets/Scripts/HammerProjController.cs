using UnityEngine;
using System.Threading.Tasks;
public class HammerProjController : MonoBehaviour
{
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async Task Start()
    {
        await DeleteProj();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private async Task DeleteProj()
    {
        await Task.Delay(2000);
        Destroy(gameObject);
    }
}
