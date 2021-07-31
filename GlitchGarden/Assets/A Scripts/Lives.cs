using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] TextMeshProUGUI livesText;

    [SerializeField] GameObject LosePanel;
    // Start is called before the first frame update

    public void DecreareLives()
    {
        lives--;
        livesText.text = "Live:" + lives;

        if (lives <= 0)
        {
            LosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void Start()
    {
        string difficulty = PlayerPrefsController.GetDifficulty();
        if (difficulty == "Easy")
        {
            lives = 5;
        }else if (difficulty == "Medium")
        {
            lives = 3;
        }else if (difficulty == "Hard")
        {
            lives = 1;
        }

        livesText.text = "Live:" + lives;
    }

   
}
