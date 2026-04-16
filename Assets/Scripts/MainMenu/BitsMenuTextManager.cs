using UnityEngine;
using TMPro;
public class BitsMenuTextManager : MonoBehaviour
{
    [SerializeField] private TMP_Text bitsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bitsText.text = "Bits: " + BitsCurrencyStorer.coinCount.ToString();
    }
}
