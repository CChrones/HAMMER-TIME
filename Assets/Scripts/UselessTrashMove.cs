using UnityEngine;

public class UselessTrashMove : MonoBehaviour
{
    [SerializeField] private SeesawMechanics SM;
    [SerializeField] private Vector3 pos1;
    [SerializeField] private Vector3 pos2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SM.isLeftDown == false){
            transform.position = new Vector3 (pos1.x, pos1.y, pos1.z);

        }else{
            transform.position = new Vector3 (pos2.x, pos2.y, pos2.z);
        }
    }
}
