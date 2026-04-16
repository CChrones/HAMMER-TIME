using UnityEngine;

public class BuyHammerSpin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(AbilitiesUnlocked.hasHammerSpin == true)
        {
            Destroy(gameObject);
        }
    }
    public void DoBuyHammerSpin()
    {
        if(BitsCurrencyStorer.coinCount >= 100)
        {
            BitsCurrencyStorer.coinCount -= 100;
            AbilitiesUnlocked.hasHammerSpin = true;
            Destroy(gameObject);
        }
        
    }
}
