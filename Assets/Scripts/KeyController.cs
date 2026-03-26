//****************************************************************************
// File Name :         KeyController.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     Key system for the player
//****************************************************************************
using UnityEngine;
using TMPro;
public class KeyController : MonoBehaviour
{
    [SerializeField] private TMP_Text keyText;
    //[SerializeField] private AudioSource collectSound;
    public int keyCount;
    public int keyRequirement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keyCount = 0;
        keyText.text = "Keys: " + keyCount.ToString() + "/" + keyRequirement.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Increases the key total and destroys the key (it has been collected)
    /// </summary>
    /// <param name="triggerObject"></param>
    private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Key"))
        {
            keyCount++;
            /*if(collectSound != null){
                collectSound.Play();
            }*/
            keyText.text = "Keys: " + keyCount.ToString();
            Destroy(triggerObject.gameObject);
        }
    }

}
