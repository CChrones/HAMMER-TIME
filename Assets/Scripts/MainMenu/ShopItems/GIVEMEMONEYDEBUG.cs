using UnityEngine;

public class GIVEMEMONEYDEBUG : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GiveMeMoneyPleaseImBeggingYou()
    {
        BitsCurrencyStorer.coinCount += 100;
    }
}
