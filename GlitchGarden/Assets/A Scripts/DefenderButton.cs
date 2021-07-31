using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    //[SerializeField] DefenderButton[] defenderButtons; we could use it instead of "var buttons = FindObjectsOfType<DefenderButton>();"
    
    [SerializeField] Defender defenderPrefab;
    DefenderSpawner defenderSpawner;

    [SerializeField] int DefenderCost;
    [SerializeField] TextMeshProUGUI DefenderCostText;

    private void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(var button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        defenderSpawner.SetSelectedDefender(defenderPrefab);

        DefenderCostText.text = "Cost: " + DefenderCost;
    }
}
