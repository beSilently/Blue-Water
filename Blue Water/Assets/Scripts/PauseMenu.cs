using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public static KeyCode PauseButton { get; set; }

    private void Start()
    {
        string pauseButton = PlayerPrefs.GetString("PauseButton", "Escape");
        PauseButton = (KeyCode)System.Enum.Parse(typeof(KeyCode), pauseButton);
    }

    void Update () {
        if (Input.GetKeyDown(PauseButton)) {
            if (gameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
	}
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void QuitGame() {
        Application.Quit();
    }
}
