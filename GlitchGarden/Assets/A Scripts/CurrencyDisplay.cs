using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class CurrencyDisplay : MonoBehaviour
{
    [SerializeField] int money;
    TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public int GetMoney()
    {
        return money;
    }

    private void UpdateDisplay()
    {
        moneyText.text = "Coin: " + money;
    }
    public void SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            UpdateDisplay();
        }
        
    }
    public void AddMoney(int amount)
    {
            money += amount;
            UpdateDisplay();
    }


}
