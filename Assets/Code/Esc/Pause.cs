using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPaused = false, isPauseMenu = true;
    [SerializeField] private GameObject PauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauseMenu)
            {
                if (isPaused)
                {
                   ResumeGame();
                }
                else
                {
                    PauseMenu.SetActive(true);
                    isPaused = true;
                    Time.timeScale = 0f;
                }
            }
            
        }
    }
    #region Buttons

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Retry()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Filler");
        SceneManager.LoadScene(i);
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        print("see you!");
        Application.Quit();
    }
    public void GameMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
