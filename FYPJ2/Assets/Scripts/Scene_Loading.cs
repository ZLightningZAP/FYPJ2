using UnityEngine;

public class Scene_Loading : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        if (GameControl._control.Load())
            GetComponent<Scene_navigation>().GoTo_MainMenu();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}