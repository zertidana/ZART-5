using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Reference to the main menu canvas
    public GameObject mainMenuCanvas;

    // Reference to the settings menu canvas
    public GameObject settingsMenuCanvas;

    public void PlayGame()
    {
        // Load the game scene (assuming it's at index 1)
        SceneManager.LoadSceneAsync(1);
    }

    public void SettingsGame()
    {
        // Hide the main menu canvas
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.SetActive(false);
        }

        // Show the settings menu canvas
        if (settingsMenuCanvas != null)
        {
            settingsMenuCanvas.SetActive(true);
        }
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}