//****************************************************************************
// File Name :         CoinController.cs
// Author :            Cameron Chrones
// Creation Date :     March 25th, 2026
// Brief Description : This file is 3D Platformer Alpha for IM 160, coding the
//                     ability for the player to collect coins
//****************************************************************************
using UnityEngine;
using TMPro;
public class CoinController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    //[SerializeField] private AudioSource collectSound;
    private int coinCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinCount = 0;
        coinText.text = "Bits: " + coinCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Increases the coin total and destroys the coin (it has been collected)
    /// </summary>
    /// <param name="triggerObject"></param>
    private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Coin") && !gameObject.CompareTag("HammerHitbox"))
        {
            coinCount++;
            /*if(collectSound != null){
                collectSound.Play();
            }*/
            coinText.text = "Bits: " + coinCount.ToString();
            Destroy(triggerObject.gameObject);
        }
        if (triggerObject.gameObject.CompareTag("BigCoin") && !gameObject.CompareTag("HammerHitbox"))
        {
            coinCount += 10;
            /*if(collectSound != null){
                collectSound.Play();
            }*/
            coinText.text = "Bits: " + coinCount.ToString();
            Destroy(triggerObject.gameObject);
        }
    }
}
