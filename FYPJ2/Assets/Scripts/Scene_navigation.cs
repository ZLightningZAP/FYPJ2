using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_navigation : MonoBehaviour {

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
}
