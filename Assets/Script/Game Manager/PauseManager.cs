using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private static bool gameIsPaused;
    public GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            PauseGame();
        }
    }
    public void PauseGame()
    {
        if (!gameIsPaused)
        {
            gameIsPaused = !gameIsPaused;
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            gameIsPaused = !gameIsPaused;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            AudioListener.pause = false;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        AudioListener.pause = false;
    }

    public void ExitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
