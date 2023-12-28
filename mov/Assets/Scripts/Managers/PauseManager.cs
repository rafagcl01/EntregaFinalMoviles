using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PauseManager : MonoBehaviour
{

    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameManager World;


    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        World.Paused = false;
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        World.Paused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

}
