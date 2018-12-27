using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class OptionsMenu : MonoBehaviour {

    public Button escButton;
    public Button spaceButton;
    public Button backButton;
    public TMP_Dropdown resolutionDropdown;
    public Color chosenButtonColor;
    public Color normalButtonColor;

    string pauseButtonPrefs;
    Resolution[] resolutions;     int currenResolutionIndex;      private void Start()     {         string pauseButton = PlayerPrefs.GetString("PauseButton", "Escape");         switch (pauseButton)         {             case "Escape":                 SetChosenButtonColor(escButton);                 break;             case "Space":                 SetChosenButtonColor(spaceButton);                 break;         }          resolutions = Screen.resolutions;         resolutionDropdown.ClearOptions();         List<string> options = new List<string>();         for (int i = 0; i < resolutions.Length; i++)         {             string option = resolutions[i].width + " x " + resolutions[i].height;             options.Add(option);              if (resolutions[i].width == Screen.width &&             resolutions[i].height == Screen.height)             {                 currenResolutionIndex = i;             }         }         resolutionDropdown.AddOptions(options);         resolutionDropdown.value = currenResolutionIndex;         resolutionDropdown.RefreshShownValue();     }      private void Update()     {         if (Input.GetKeyDown(KeyCode.Escape))         {             backButton.onClick.Invoke();         }     }      public void SetResolution(int resolutionIndex)     {         Resolution resolution = resolutions[resolutionIndex];         Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("Width", resolution.width);
        PlayerPrefs.SetInt("Height", resolution.height);
    }

    public void ChangePauseButton()
    {
        string buttonPressed = EventSystem.current.currentSelectedGameObject.name;
        switch(buttonPressed)
        {
            case "Escape":
                SetChosenButtonColor(escButton);
                SetNormalButtonColor(spaceButton);

                PauseMenu.PauseButton = KeyCode.Escape;
                PlayerPrefs.SetString("PauseButton", "Escape");
                break;
            case "Space":
                SetChosenButtonColor(spaceButton);
                SetNormalButtonColor(escButton);

                PauseMenu.PauseButton = KeyCode.Space;
                PlayerPrefs.SetString("PauseButton", "Space");
                break;
        }
    }

    private void SetChosenButtonColor(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = chosenButtonColor;
        button.colors = cb;
    }

    private void SetNormalButtonColor(Button button)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = normalButtonColor;
        button.colors = cb;
    }
}
