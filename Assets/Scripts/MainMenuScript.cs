using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public GameObject creditsMenu;
    public TMP_Dropdown graphicsQuality;
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void CreditsMenu()
    {
        creditsMenu.SetActive(!creditsMenu.activeSelf);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeQualitySettings()
    {
        QualitySettings.SetQualityLevel(graphicsQuality.value);
    }
}
