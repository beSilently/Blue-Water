using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start()     {         if (PlayerPrefs.HasKey("Width"))         {             Screen.SetResolution(PlayerPrefs.GetInt("Width"), PlayerPrefs.GetInt("Height"), Screen.fullScreen);         }     }

    public void PlayGame() 
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Back() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
