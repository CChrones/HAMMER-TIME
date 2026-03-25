using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
public class PortalSummonScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesToSummon = new List<GameObject>();
    [SerializeField] private List<GameObject> enemiesSummoned = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async Task Start()
    {
        await SummonFromPortal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private async Task SummonFromPortal()
    {
        for(int i = 0; i < enemiesToSummon.Count;)
        {
            CleanESList();
            if(enemiesSummoned.Count < 2)
            {
                enemiesSummoned.Add(Instantiate(enemiesToSummon[i], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity));
                enemiesToSummon.Remove(enemiesToSummon[i]);
                await Task.Delay(5000);
            }
            else
            {
                await Task.Delay(5000);
            }
        }
    }
    void CleanESList()
    {
        // Remove all entries where the item is null
        enemiesSummoned.RemoveAll(gameObject => gameObject == null);
        Debug.Log("List cleaned. New count: " + enemiesSummoned.Count);
    }
}
