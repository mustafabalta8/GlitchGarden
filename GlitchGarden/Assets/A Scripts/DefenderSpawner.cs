using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] Defender defender;
    GameObject defenderParent;
    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    private void OnMouseDown()
    {
        if (defender == null) { return; }
        AttemptToPlaceDefenderAt();
    }
    public void SetSelectedDefender(Defender DefenderToSelect)
    {
        defender = DefenderToSelect;
    }
    private void SpawnDefender()
    {


        Vector2 mousePosition = Input.mousePosition;
        Vector2 WordPos = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 FinalPositionOfDefender = SnapToGrid(WordPos) + new Vector2(0f, 0.1f);//(0f, 0.1f) added to instantiate the object at the correct place at the grid/area
        
      
        Instantiate(defender, FinalPositionOfDefender, transform.rotation, defenderParent.transform); //Defender newDefender = Instantiate(Defender, FinalPositionOfDefender, transform.rotation) as Defender;

    
    }
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }
    private void AttemptToPlaceDefenderAt()
    {
        var MoneyDisplay = FindObjectOfType<CurrencyDisplay>();
        int defenderCost = defender.GetCost();

        if (MoneyDisplay.GetMoney() >= defenderCost)
        {
            SpawnDefender();
            MoneyDisplay.SpendMoney(defenderCost);
        }
    }
    

    
}
