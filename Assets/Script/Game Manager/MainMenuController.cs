using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject howToPlayPanel;
    public GameObject creditsPanel;

    public void Start()
    {
        mainMenuPanel.SetActive(true);
    }

    public void PlayGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Lapangan");
    }
    public void LoadHowToPlayScene()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
        //SceneManager.LoadScene("How To Play");
    }
    public void LoadCredits()
    {
        howToPlayPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
        //SceneManager.LoadScene("Credits");
    }
    public void MainMenu()
    {
        creditsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        //SceneManager.LoadScene("Main Menu");
    }
    public void ExitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
}
