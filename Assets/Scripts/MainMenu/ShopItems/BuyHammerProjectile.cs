using UnityEngine;

public class BuyHammerProjectile : MonoBehaviour
{
void Start()
    {
        if(AbilitiesUnlocked.hasHammerProjectile == true)
        {
            Destroy(gameObject);
        }
    }
    public void DoBuyHammerProjectile()
    {
        if(BitsCurrencyStorer.coinCount >= 200)
        {
            BitsCurrencyStorer.coinCount -= 200;
            AbilitiesUnlocked.hasHammerProjectile = true;
            Destroy(gameObject);
        }
        
    }
}
