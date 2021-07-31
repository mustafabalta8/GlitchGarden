using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int Health;
    [SerializeField] int Cost;

   // [SerializeField] GameObject Star;

    CurrencyDisplay currencyDisplay;
    public int GetCost()
    {
        return Cost;
    }
    private void Start()
    {
        currencyDisplay = FindObjectOfType<CurrencyDisplay>();

    }

    public void AddMoney(int amount)// for throphy 
    {
        currencyDisplay.AddMoney(amount);
       //GameObject StarObj = Instantiate(Star, transform.position, transform.rotation);
        //Destroy(StarObj, 1f);
    }
    public void DecreaseHealth(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

