using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject blueprintMenu;
    private bool isPauseMenuActive = false;
    private bool isBlueprintMenuActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isBlueprintMenuActive) CloseBlueprintMenu();
            TogglePauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (isPauseMenuActive) ClosePauseMenu();
            ToggleBlueprintMenu();
        }
    }

    public void TogglePauseMenu()
    {
        isPauseMenuActive = !isPauseMenuActive;
        if (isPauseMenuActive) OpenPauseMenu();
        else ClosePauseMenu();
    }

    public void ToggleBlueprintMenu()
    {
        isBlueprintMenuActive = !isBlueprintMenuActive;
        if (isBlueprintMenuActive) OpenBlueprintMenu();
        else CloseBlueprintMenu();
    }

    private void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    private void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void OpenBlueprintMenu()
    {
        blueprintMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CloseBlueprintMenu()
    {
        blueprintMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
