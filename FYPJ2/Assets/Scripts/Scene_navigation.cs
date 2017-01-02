using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_navigation : MonoBehaviour
{
    public void GoTo_Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void GoTo_Gameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GoTo_Exit()
    {
        Application.Quit();
    }

    public void GoTo_MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        //Plays the background music
        AudioManager.PlayBackgroundMusic(AudioManager.BackgroundMusic.MainMenu);
    }

    public void GoTo_Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void DEBUG_Saving()
    {
        GameControl._control.Save();
    }
}