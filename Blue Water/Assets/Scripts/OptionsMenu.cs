using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour {

    public Button escButton;
    public Button spaceButton;
    public Button backButton;
    public Color chosenButtonColor;
    public Color normalButtonColor;

    string pauseButtonPrefs;

    private void Start()
    {
        string pauseButton = PlayerPrefs.GetString("PauseButton", "Escape");
        switch(pauseButton)
        {
            case "Escape":
                SetChosenButtonColor(escButton);
                break;
            case "Space":
                SetChosenButtonColor(spaceButton);
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            backButton.onClick.Invoke();
        }
    }

    public void SetQuality (int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
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
