using UnityEngine;
using System.Collections.Generic;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Menu1 = new List<GameObject>();
    [SerializeField] private List<GameObject> Menu2 = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exitAllListItems(Menu2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void exitAllListItems(List<GameObject> List)
    {
        for(int i = 0; i < List.Count; i++)
        {
            List[i].SetActive(false);
        }
    }
    public void enterAllListItems(List<GameObject> List)
    {
        for(int i = 0; i < List.Count; i++)
        {
            List[i].SetActive(true);
        }
    }
    public void enterMenu2()
    {
        exitAllListItems(Menu1);
        enterAllListItems(Menu2);
    }
    public void enterMenu1()
    {
        exitAllListItems(Menu2);
        enterAllListItems(Menu1);
    }
}
