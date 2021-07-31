using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int CurrentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
       
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(CurrentSceneIndex==0)
        StartCoroutine(LoadStart());
    }

    IEnumerator LoadStart()
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(CurrentSceneIndex+1);
        Time.timeScale = 1;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(CurrentSceneIndex);
        Time.timeScale = 1;
    }
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
